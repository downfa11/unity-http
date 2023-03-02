from flask import Flask,request,jsonify

app = Flask(__name__)



@app.route('/getDataFromServer', methods=['POST'])
def getDataFromServer():
    # 클라이언트로부터 JSON 데이터를 받습니다.
    data = request.get_json()
    print(data)
    result="send success."

    return jsonify(result)


if __name__ == "__main__":
       app.run(host='0.0.0.0', port=int(80))