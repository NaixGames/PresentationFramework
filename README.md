# PresentationFramework
 A framework for making presentations in Godot using C#.

# How to use
Each slide of the presentation needs to have a SlidePresentacion script as a top component. In each slide, the "bullet points" should have a bullet point script. The bullet points refer to the different items that are going to appear when advancing through the presentation in each slide.

The slides are organized by a presention manager. This should be attached as a parent script on a top level component. Then each slide should be assigned on the inspector on the script.  Going back and forth in each bullet point (and slide when bullet points are finished) is done with the right and left arrows (feel free to change that by changing the InputMap).
