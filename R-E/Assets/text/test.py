import json


while(True):
    with open("light_signal.json",'r') as f:
        json_file=json.load(f)
    signal = input("변경할 신호등 번호, 신호을 공백으로 구분하여 입력>>").split(' ')

    json_file["signal"][signal[0]]=signal[1]
    print(json_file)
    with open("light_signal.json",'w') as k:
        json.dump(json_file,k,indent='\t')
