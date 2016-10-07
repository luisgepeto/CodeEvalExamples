import sys

class Virus(object):
    def __init__(self, virus_string, virus_type):
        self.virus_string = virus_string
        self.virus_type = virus_type

    def get_components(self):
        return self.virus_string.split()

    def get_hex_value(self, virus_component):
        return int(virus_component, 16)

    def get_bin_value(self, virus_component):
        return int(virus_component, 2)

    def get_sum(self):
        summed_virus =0
        for component in self.get_components():
            if self.virus_type == "virus":
                summed_virus += self.get_hex_value(component)
            elif self.virus_type == "antivirus":
                summed_virus += self.get_bin_value(component)
        return summed_virus


with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        virus_string = test.split("|")[0]
        antivirus_string = test.split("|")[1]
        virus = Virus(virus_string, "virus")
        antivirus = Virus(antivirus_string, "antivirus")
        print(antivirus.get_sum() >= virus.get_sum())
