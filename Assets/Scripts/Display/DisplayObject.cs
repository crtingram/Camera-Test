using System;

public class DisplayObject {

    public string displayImagePath { get; }
    public string description { get; }

    public bool showResourcePanel = false;

    public DisplayObject(string displayImagePath, string description) {
        this.displayImagePath = displayImagePath;
        this.description = description;
    }

}
