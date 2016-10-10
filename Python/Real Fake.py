import sys

class CreditCard(object):
    def __init__(self,  number):
        self.number = number.rstrip()

    def get_groups(self):
        return self.number.split(" ")

    def get_sum(self, group):
        sum =0
        for i, value in enumerate(group):
            number = int(value)
            if i % 2 == 0:
                sum += number *2
            else:
                sum+= number
        return sum

    def is_valid(self):
        sum = 0
        for group in self.get_groups():
            sum += self.get_sum(group)
        return sum % 10 == 0


with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        credit_card = CreditCard(test)
        if credit_card.is_valid(): print("Real")
        else: print("Fake")