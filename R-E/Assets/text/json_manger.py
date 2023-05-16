import json
class json_manger:
    def __init__(self):
        self.json_name="light_signal.json"
    def __init__(self,light_signal):
        self.json_name=light_signal
    def change(self,number,signal):
        with open(self.json_name,"r") as f:
            json_file = json.load(f)
        json_file["traffics"]["at_road"+str(number)]["CurrentState"]=signal
    
