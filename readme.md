# Groan

Groan is a simple Winforms tool to assist in visualizing random noise, using different approaches.

Initially Perlin noise is supported.

# Notes
App design uses a Passive view approach, where the view has little to no logic in (where it can't be easily tested).

Most of the work will be found in `Presenter` components, which can mock dependencies as required for testing.

Uses .NET Dependency Injection package to implement IoC.

# TODOS

* Save to image file
* Save config used to produce current map
