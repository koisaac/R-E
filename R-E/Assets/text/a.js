const fs = require("fs");

module.exports = class File{
    constructor(){
        this.filesList = {};
        this.access = {};
        this.accessCount = 0;
    }

    init(id, data){
        if (!this.access[id])
        {
             console.error(`ERROR\nNo Such An ID : ${id}`);
        }

        this.editData(id, [], data);
    }
    
    newFile(url = null, address = [], data){
        let currentFile = null;
        let id = this.accessCount;

        let isFileLoaded = false;

        if (this.filesList[url]) currentFile = this.filesList[url];

        else{
            try { currentFile = require(url); isFileLoaded = true; }
            catch(e) { if (!isFileLoaded) console.error(`ERROR\nUnaccessible to File URL : ${url}`); }

            this.filesList[url] = {};
        }

        this.access[id] = {
            "id" : id,
            "url" : url,
            "address" : address
        };

        this.init.bind(this)(id, data);

        this.accessCount++;

        return id;
    }

    editData(id, _address = [], data, warn = false){
        if (!_address) return;
        if (!this.access[id]) console.error(`ERROR\nNo Such an ID : ${id}`);

        const url = this.access[id].url;
        const address = this.access[id].address.concat(_address);

        let currentObject = null;
        let WholeFile = null;

        WholeFile = this.filesList[url];
        currentObject = WholeFile;

        for (let i = 0; i < address.length - 1; i++){
            if (!currentObject[address[i]]){
                currentObject[address[i]] = {};

                if (warn) console.warn(`WARNING\nAccessing Undefined Key : ${address[address.length - 1]}`);
            }

            currentObject = currentObject[address[i]];
        }

        if (address.length > 0) currentObject[address[address.length - 1]] = data;
        
        this.filesList[url] = WholeFile;

        this.applyToFile.bind(this)(url);
    }

    addressFollower(obj, address, doCrash = true){
        for (let key of address){
            if (!obj[key] && doCrash){
                console.error(`ERROR\nUnaccessible : ${address}`);

                return;
            }

            obj = obj[key];
        }

        return obj;
    }

    applyToFile(url){
        let updatedJson = JSON.stringify(this.filesList[url], null, 4);

        fs.writeFileSync(url, updatedJson, "utf8", (err) => {
            if (err) console.error(`ERROR\nHaving a Problem Accessing To : ${url}\n${err}`);
        });
    }
}