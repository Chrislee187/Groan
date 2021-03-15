# Groan

Groan is a simple Winforms tool to assist in visualizing random noise, using different approaches.

Initially Perlin noise is supported.

# Notes
App design uses a Passive view approach, where the view has little to no logic in (where it can't be easily tested).

Most of the work will be found in `Presenter` components, which can mock dependencies as required for testing.

"change/selected" type events are only triggered when the user interacts with controls on the form and are disabled when the `Presenter` changes values to avoid triggering endless event cascades. (i.e. user updates a slider, which also updates a textbox showing the sliders value, this triggers the textbox change event, which updates the slider value, repeat...).


Uses .NET Dependency Injection package to implement IoC.

# TODOS

* Save to image file
* Save config used to produce current map
