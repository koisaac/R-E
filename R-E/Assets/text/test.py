import json_manger



jn = json_manger.json_manger()
while(True):
    signal = input("변경할 신호등 번호, 신호을 공백으로 구분하여 입력>>").split(' ')
    jn.change(signal[0],signal[1])
    if(bool(input("종료할 경우 -1 입력")!="-1" if True else False)):
        break