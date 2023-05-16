import json
class json_manger:
    def __init__(self):

        self.json_name="light_signal.json"
        print(self.json_name)


        j=0
        with open(self.json_name,"r") as f:
            j = json.load(f)
            for i in range(len(j["traffics"])):
                j["traffics"]["at_road"+str(i+1)]["CurrentState"]="red"
        with open(self.json_name,"w") as f:
            f.writelines(json.dumps(j,indent=2))

    def change(self,number,signal):
        json_file = 0

        with open(self.json_name,"r") as f:
            json_file = json.load(f)

        print(len(json_file["traffics"]))
        
        json_file["traffics"]["at_road"+str(number)]["CurrentState"]=signal
        
        with open(self.json_name,"w") as f:
            print(json.dumps(json_file, indent=2))
            f.writelines(json.dumps(json_file, indent=2))
    def __del__(self):
        j=0
        with open(self.json_name,"r") as f:
            j = json.load(f)
            for i in range(len(j["traffics"])):
                j["traffics"]["at_road"+str(i+1)]["CurrentState"]="red"
        with open(self.json_name,"w") as f:
            f.writelines(json.dumps(j,indent=2))


