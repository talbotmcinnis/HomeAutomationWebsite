Deploying
---------

In video studio, Publish using HTPC Package, which will produce a .zip, .cmd and a few other files.

Edit the 804ManchesterHomeControl.SetParameters.xml and change the IIS site name to default, i.e.: name="IIS Web Application Name" value="Default Web Site/"

Copy them all to the media PC, then run the .cmd with /T to test and /Y to deploy.