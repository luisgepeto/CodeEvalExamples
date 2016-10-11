import sys
class TeamsDictionary(object):
    def __init__(self):
        self.teams = {}

    def add_team(self, team, country):
        if team not in self.teams:
            self.teams[team] = []
        self.teams[team].append(country)

    def __repr__(self):
        repr = ""
        for team in sorted(self.teams):
            repr += team+ ":"
            repr += ','.join(map(str, sorted(self.teams[team])))
            repr += "; "
        return repr.strip()


class Country(object):
    def __init__(self,  country_id, teams_string, teams_dictionary):
        self.country_id = country_id
        self.teams = teams_string.split(" ")
        self.teams_dictionary = teams_dictionary

    def process(self):
        for team in self.teams:
            self.teams_dictionary.add_team(team, self.country_id)



with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        teams_dictionary = TeamsDictionary()
        for i, teams_string in enumerate(test.rstrip().split("|")):
            country = Country(i+1, teams_string.strip(), teams_dictionary)
            country.process()
        print(repr(teams_dictionary))

