import sys

morse_dictionary = {
    '.-':'A',
    '-...':'B',
    '-.-.':'C',
    '-..':'D',
    '.':'E',
    '..-.':'F',
    '--.':'G',
    '....':'H',
    '..':'I',
    '.---':'J',
    '-.-':'K',
    '.-..':'L',
    '--':'M',
    '-.':'N',
    '---':'O',
    '.--.':'P',
    '--.-':'Q',
    '.-.':'R',
    '...':'S',
    '-':'T',
    '..-':'U',
    '...-':'V',
    '.--':'W',
    '-..-':'X',
    '-.--':'Y',
    '--..':'Z',
    '.----':'1',
    '..---':'2',
    '...--':'3',
    '....-':'4',
    '.....':'5',
    '-....':'6',
    '--...':'7',
    '---..':'8',
    '----.':'9',
    '-----':'0'
}

class Letter(object):
    def __init__(self, morse_string):
        self.morse_string = morse_string

    def __repr__(self):
        return morse_dictionary[self.morse_string]

class Word(object):
    def __init__(self, letters):
        self.letters = letters

    def __repr__(self):
        return ''.join(map(lambda x: repr(x), self.letters))

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        print(' '.join(map(str, map(lambda mw: Word(map(lambda ml: Letter(ml), mw.split(" "))), test.rstrip().split("  ")))))