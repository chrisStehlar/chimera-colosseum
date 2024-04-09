<h1> Git Branches</h1>
Use branches for different features when working on Chimera Colosseum.

Name your branch "usr/yourInitials/nameOfFeature" so they are easy to identify, and if there are old branches laying around we know who made them and we can ask them if we can delete it or not.
ex. "usr/cms/branchesDocumentation"

**With branches, we can make pull requests to the main branch instead of just pumping updates straight to main. This could avoid breaking our main branch.** Pull requests are also great opportunities to review your code and have others review it before it goes to main. That way, we are all on the same page about the state of the project.

If you don't know how to make a branch: from the command line, if you navigate to the repo (ex. cd location/of/repo/on/your/computer) then type "git status" you can see which branch you are working on. When you want to make a new branch, get on main and then type "git checkout -b usr/cms/branchName" and that will create a new branch off of main called branchName.
If you are done with the feature on your branch, type "git push" to upload the changes to the remote version of the branch (if it says you need to configure where you are pushing, just copy paste the suggestion to "set upstream false" or something like that). Once you push your branch, you will see it in the "pull requests" tab on our repo. At this point, take a look at your changes, make clean ups where needed, and then when you think it is good, send a link to the PR in the discord so someone else can review and approve it.
Once you are done with your branch and it has been merged, get back on main ("git checkout main") pull the latest changes (your additions) to your local repo, and then checkout a new branch for your next feature.