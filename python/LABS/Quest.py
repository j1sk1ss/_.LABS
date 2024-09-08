class Quest:
    def __init__(self, quests):
        self.quests = quests

    def open(self):
        while True:
            answer = input(f'\r\nSelect task number between 0 and {len(self.quests) - 1}: ')
            if answer == 'exit':
                break

            self.quests[int(answer)]()
