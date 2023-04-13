const _FILE = require("./file");
const FILE = new _FILE();

class App{
    constructor(_file, keys = null){
        this.id = FILE.newFile(_file, keys);
        this.jsonLocation = _file;
    }

    editFile(keys = [], value = null){
        FILE.editFile(this.id, keys, value);
    }
}

const file = '../DATA/traffic.json';
const app = new App(file, ["traffics", "at_road1"]);

app.editFile(["CurrentState"], "red");