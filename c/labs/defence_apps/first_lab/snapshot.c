#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/utsname.h>
#include <sys/stat.h>
#include <zlib.h>

#ifdef __linux__
    #include <sys/sysinfo.h>
#elif __APPLE__
    #include <sys/types.h>
    #include <sys/sysctl.h>
#endif

#define SNAPSHOT_FILE "snap.snp"


typedef struct {
    unsigned int crc32_hash;
    char system_name[64];
    char node_name[64];
    char release[64];
    char machine[64];
} snapshot_t;


static int _print_snap(snapshot_t snap) {
    printf(
        "Snapshot: \nName: %s\nNode name: %s\nRelease: %s\n Machine: %s\nCRC32: %u\n",
        snap.system_name, snap.node_name, snap.release, snap.machine, snap.crc32_hash
    );
    return 1;
}

static unsigned int _calculate_crc32(const void *data, size_t length) {
    return crc32(0L, data, length);
}

int _save_snap(snapshot_t* snapshot) {
    int fd = open(SNAPSHOT_FILE, O_WRONLY | O_CREAT | O_TRUNC, 0666);
    if (fd < 0) {
        perror("open");
        return -1;
    }

    if (write(fd, snapshot, sizeof(snapshot_t)) != sizeof(snapshot_t)) {
        perror("write");
        close(fd);
        return -1;
    }

    close(fd); 
    return 1;   
}

int _create_snapshot(snapshot_t* snapshot) {
    memset(snapshot, 0, sizeof(snapshot_t));
    struct utsname sys_info;
    if (uname(&sys_info) < 0) {
        perror("uname");
        return -1;
    }

    strncpy(snapshot->system_name, sys_info.sysname, sizeof(snapshot->system_name));
    strncpy(snapshot->node_name, sys_info.nodename, sizeof(snapshot->node_name));
    strncpy(snapshot->release, sys_info.release, sizeof(snapshot->release));
    strncpy(snapshot->machine, sys_info.machine, sizeof(snapshot->machine));
    snapshot->crc32_hash = _calculate_crc32(snapshot, sizeof(snapshot_t) - sizeof(unsigned int));
    return 0;
}

int check_snapshot() {
    snapshot_t current_snapshot;
    _create_snapshot(&current_snapshot);

    int fd = open(SNAPSHOT_FILE, O_RDONLY);
    if (fd < 0) {
        _save_snap(&current_snapshot);
        return -1;
    }

    snapshot_t saved_snapshot;
    if (read(fd, &saved_snapshot, sizeof(snapshot_t)) != sizeof(snapshot_t)) {
        perror("read");
        close(fd);
        return -1;
    }

    close(fd);
    if (saved_snapshot.crc32_hash == current_snapshot.crc32_hash) return 1;
    else return 0;
}
