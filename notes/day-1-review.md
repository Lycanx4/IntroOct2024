# Day 1 Review

Please address your current understanding of the following topics we covered (or began to cover) in class today. Your thoughts about these can and should be revised throughout the training (and your career!) as your understanding grows.

I am *not* looking for super "technical" stuff here. Just your ability to express and convey in your way your understanding of these things.

## 1. Git

We created a git repository on our VMs and added some existing code and committed it. We then used the `gh` cli tool to push that code to Github. 

- Say a few words about why *we* are using source control in this class?

It tracks changes, help collaboration and allows us to revert to earlier stage if needed.

- Say a few words about how source control is used by teams of developers working on the same code base.

manage changes, collaborate without conflits, merge code safely, easily track who did the changes

- What is meant when we say a copy of the repository is the "origin"? (That's our copy on github).

It is the main remote repo where the code is stored.

- Why do we create commits locally?

To save and track changes before pushing to remote

- Why do we push those commits to Github?

To save it on remote repo (for sharing with othe or back up our code) 


### Extra Credit

What were the steps, as detailed as you like, that we took to create our repository and push it to Github.

initiate git >>> add file to git >>> commit the changes >>> create repo and remote orgin

What are some other ways you might do the same thing?

Create repo at GitHub.com and get URL from there
git init >>> git add . >>> git commit -m "Message" >>> git remote add origin (Your remote URL) >>> git push -u origin master/(somethime 'main')


## 2. Services

We began a project in Visual Studio to create a service. What is meant by the term "Service" in software development?

It is a thing that performs a specific task.

Our service exposes an *interface* that other applications can use to drive our service (make it do stuff). This is an
"Application Programming Interfact". How does an API differ from a "User Interface" (UI)? How are they similiar?

-UI is for user interaction (i.e visual elements on screen, forms, buttons, etc.)
-API is for system to system interaction.
-Both of them are client for a service.

What are some benefits of exposing a service's interface using the HTTP Protocol?

-compatibility across platforms, simplicity, helpful for creating scalable web services.

We "tested" our API three different ways. 

1. Manually using SwaggerUI
2. Manually using the `.http` file functionality in Visual Studio
3. Automated using an xUnit test project.

Which is the *right* way to do it? Why give preference to automated tests? 

I believe there is no wrong way to approach it, but I prefer automated testing as the best option. 
Because of its Time Efficiency, Consistency, Cover a wider range of scenarios, and able to implement Continuous Integration

### Extra Credit

Have you used any existing HTTP APIs in other projects?

Yes, I used multiple APIs in my previous projects. (Such as youtube API, other data api)

Have you created any other HTTP APIs in your own work or studies?

Yes, I have created HTTP APIs during my studies. 
