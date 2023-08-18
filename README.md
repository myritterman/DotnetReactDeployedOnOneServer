### The goal of this app is to create a dev environment using a separate backend and frontend server
#### Special thanks to the creator of [this](https://www.kambu.pl/blog/how-to-deploy-a-react-app-together-with-net-backend-to-azure-with-azure-devops/) article for guiding me through the process

###### Step 1: (Code can be found [here](https://github.com/myritterman/DotnetReactDeployedOnOneServer/commit/6f486b9007f99eefcaccc2fd9b1dbcc58c04cfc0))
 * Create a MVC Webapp for the backend. In this case, we'll call the solution _DotnetReactDeployedOnOneServer_ and a project name _DotnetReactDeployedOnOneServer.Web_

<img width="1066" alt="Backend solution" src="https://github.com/myritterman/DotnetReactDeployedOnOneServer/assets/82187863/51af2a66-a402-465d-aeb9-f33fb513177c">

 * Create the frontend using create react app. Within the web project (_DotnetReactDeployedOnOneServer.Web_), run `npx create-react-app clientapp`.

At this point, we have a file structure looking like this

<img width="486" alt="image" src="https://github.com/myritterman/DotnetReactDeployedOnOneServer/assets/82187863/e6377d57-e878-4ddb-a84c-bc0738bdba83">

###### Step 2: (Code can be found [here](https://github.com/myritterman/DotnetReactDeployedOnOneServer/commit/4e302bb5f25a15d8daef44cf72c03f49515baaab))
* Create an endpoint on the backend to test our app
* Modify `App.js` so that we have an API request going from the frontend to the backend
* Proxy requests going from the frontend to the backend so that we don't have any CORS issues

###### Step 3: (Code can be found [here](https://github.com/myritterman/DotnetReactDeployedOnOneServer/commit/5413f8121e2e7be3b1b2f99e6462b2c9fad90d47))
The idea here is that if the user hits any endpoint that doesn't exist on the backend, we'll fall back onto the route of our choice in our case we'll route the request to our react app.
As the code is now it's not possible but as we'll see in a future step, we'll use our GitHub Actions workflow to move the react build file to a place that's accessible to the .Net app

###### Step 4: (Code can be found [here](https://github.com/myritterman/DotnetReactDeployedOnOneServer/commit/d10e095d4c1471aae34c6a09f9dc26472bde2052))
Create an app service on Azure for our web app and connect it to the GitHub repo. This can be done in the deployment center on the Azure portal. Azure will then go and generate a yml file for the workflow and pass in the necessary variables needed for the ci/cd.
This workflow won't work because the .Net app doesn't yet have access to the react code base. This will be resolved in the next step

###### Step 5: (Code can be found [here](https://github.com/myritterman/DotnetReactDeployedOnOneServer/blob/master/.github/workflows/master_dotnetreactdeployedononeserver.yml))
Update the workflow (yml file) to do the necessary steps for our app.
* Install the node dependencies and build the react app
* Copy the react build files to the backend codebase
* Build and publish the .Net solution.
* Publish to the webapp.
