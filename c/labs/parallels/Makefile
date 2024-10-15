CC = gcc-14
CFLAGS = -Wall -fopenmp
SHARED_DIR = shared/std
BINDIR = build

EXECS = $(BINDIR)/first2.bin $(BINDIR)/first3.bin $(BINDIR)/first4.bin $(BINDIR)/reference.bin
all: $(EXECS)

$(BINDIR)/first2.bin: first_lab/first_2.c | $(BINDIR)
	$(CC) $(CFLAGS) -o $@ $< $(SHARED_DIR)/matrix.c

$(BINDIR)/first3.bin: first_lab/first_3.c | $(BINDIR)
	$(CC) $(CFLAGS) -o $@ $< $(SHARED_DIR)/matrix.c

$(BINDIR)/first4.bin: first_lab/first_4.c | $(BINDIR)
	$(CC) $(CFLAGS) -o $@ $< $(SHARED_DIR)/matrix.c

$(BINDIR)/reference.bin: first_lab/reference.c | $(BINDIR)
	$(CC) $(CFLAGS) -o $@ $< $(SHARED_DIR)/matrix.c

$(BINDIR):
	mkdir -p $(BINDIR)

clean:
	rm -f $(EXECS)
