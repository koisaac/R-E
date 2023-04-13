const fs = require("fs");

module.exports = class File{
    constructor(){
        this.filesList = {};
        this.access = {};
        this.accessIDCount = 0;
    }
    
    newFile(_file = null, _keys = []){
        let currentFile = null;
        let currentObject = null;
        let id = this.accessIDCount;

        if (this.filesList[_file]) currentFile = this.filesList[_file];

        else{
            try { require(_file) }
            catch(e) { throw  `No Such A File : ${_file}` }
            finally { currentFile = require(_file) }

            this.filesList[_file] = currentFile;
        }

        currentObject = currentFile;

        for (let key of _keys){
            if (!currentObject[key]) throw `Unaccessible : ${key}\nOf ${_file}\n${_keys}`;

            currentObject = currentObject[key];
        }

        this.access[id] = {
            "id" : id,
            "file" : _file,
            "keys" : _keys
        };

        this.accessIDCount++;

        return id;
    }

    editFile(id, _keys = [], value){
        if (!_keys) return;
        if (!this.access[id]) throw `No Such an ID : ${id}`;

        const _file = this.access[id].file;
        const keys = this.access[id].keys.concat(_keys);

        let currentObject = null;
        let WholeFile = null;

        WholeFile = this.filesList[_file];
        currentObject = WholeFile;

        for (let i = 0; i < keys.length - 1; i++){
            if (!currentObject[keys[i]]) throw `Unaccessible : ${keys[i]}\nOf ${_file}\n${keys}`;

            currentObject = currentObject[keys[i]];
        }

        currentObject[keys[keys.length - 1]] = value;

        this.filesList[_file] = WholeFile;

        this.applyFile.bind(this)(_file);
    }

    applyFile(_file){
        let updatedJson = JSON.stringify(this.filesList[_file], null, 4);

        fs.writeFile(_file, updatedJson, "utf8", (err) => {
            if (err) throw `Having a Problem Accessing To : ${_file}\n${err}`;
        });
    }
}