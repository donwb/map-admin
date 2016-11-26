# VSCode .Net Core Multi-project setup example

As I'm reteaching myself C# for the hell of it, I wanted to create a basic multi-project setup as a reference.  This example includes:
* A library project, referenced by a console app and a test project  
* A global.json that binds everything together
* The proper references in project.json
* A makefile w/various targets (I like make, shoot me)
* A taskrunner that allows for building and testing inside VSCode

Any PRs and comments are welcome since before this weekend I haven't bothered w/.Net since '09.  I'm sure I'm missing stuff.
