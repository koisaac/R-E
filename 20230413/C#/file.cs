using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class File
{
    private Dictionary<string, dynamic> filesList;
    private Dictionary<int, Dictionary<string, dynamic>> access;
    private int accessIDCount;

    public File()
    {
        this.filesList = new Dictionary<string, dynamic>();
        this.access = new Dictionary<int, Dictionary<string, dynamic>>();
        this.accessIDCount = 0;
    }

    public int NewFile(string file = null, List<string> keys = null){
        string currentFile = null;
        dynamic currentObject = null;
        int id = this.accessIDCount;

        if (this.filesList.ContainsKey(file))
        {
            currentFile = this.filesList[file];
        }
        else
        {
            try
            {
                File.ReadAllText(file);
            }
            catch (Exception e)
            {
                throw new Exception($"No Such A File : {file}");
            }
            finally
            {
                currentFile = File.ReadAllText(file);
            }

            this.filesList[file] = currentFile;
        }

        currentObject = JsonConvert.DeserializeObject<dynamic>(currentFile);

        if (keys != null)
        {
            foreach (string key in keys)
            {
                if (currentObject[key] == null) throw new Exception($"Unaccessible : {key}\nOf {file}\n{keys}");

                currentObject = currentObject[key];
            }
        }

        this.access[id] = new Dictionary<string, dynamic>
        {
            { "id", id },
            { "file", file },
            { "keys", keys }
        };

        this.accessIDCount++;

        return id;
    }

    public void EditFile(int id, List<string> keys = null, dynamic value = null)
    {
        if (keys == null) return;
        if (!this.access.ContainsKey(id)) throw new Exception($"No Such an ID : {id}");

        string file = this.access[id]["file"];
        List<string> accessKeys = this.access[id]["keys"];

        if (keys != null) accessKeys.AddRange(keys);

        dynamic currentObject = null;
        dynamic wholeFile = null;

        wholeFile = JsonConvert.DeserializeObject<dynamic>(this.filesList[file]);
        currentObject = wholeFile;

        for (int i = 0; i < accessKeys.Count - 1; i++)
        {
            if (currentObject[accessKeys[i]] == null) throw new Exception($"Unaccessible : {accessKeys[i]}\nOf {file}\n{accessKeys}");

            currentObject = currentObject[accessKeys[i]];
        }

        currentObject[accessKeys[accessKeys.Count - 1]] = value;

        this.filesList[file] = JsonConvert.SerializeObject(wholeFile);

        this.ApplyFile(file);
    }

    public void ApplyFile(string file)
    {
        string updatedJson = JsonConvert.SerializeObject(this.filesList[file]);

        try
        {
            File.WriteAllText(file, updatedJson);
        }
        catch (Exception e)
        {
            throw new Exception($"Having a Problem Accessing To : {file}\n{e}");
        }
    }
}
