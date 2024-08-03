using System;

public class DisplayObject {

    public String displayImagePath { get; }
    public String description { get; }

    public bool showResourcePanel = false;

    public DisplayObject(String displayImagePath, String description) {
        this.displayImagePath = displayImagePath;
        this.description = description;
    }

}
