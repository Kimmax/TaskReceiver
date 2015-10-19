![Picture](ressources/header.png?raw=true)
# TaskReceiver
Welcome to the TaskReciever Repo!
You're here because Google brought you here, or you where just lurking around on Github, weren't you? Gotcha. Okay so let me tell what TaskReciever is.
TaskReciever is a small libary, written in C# which will open a server and waits for commands. Commands will be send in form of a simple HTTP GET request. Commands are provided in form of plugins, which will be called if a 'trigger' in form of a url part is called:
```
http://127.0.0.1/music
```
calls the plugin which has _/music_ definied as trigger.
### Okay, but why?
Why you ask? I shall tell you, you fool!
The main approach for this library is to build an endpoint for the Android Tasker+AutoVoice combination. Using Tasker and AutoVoice together will give you the possibility to control everything on your phone via voice commands. "Ok Google, turn the music on" could start the music on your phone, cool huh? Why not make it even more cooler? Instead of playing the music on your phone you could play it on your stereo if you're at home. With the power of your Voice! And this is just the beginning. You can control everything with your voice, if your computer can control it and now tell me what your computer can't control? You just have to teach him! And with this project you can! You can program your plugins in any langauge which supports the plugin interface. _Or one could code a bridge.._  
  
## Contributing
### Contributing in form of plugins
Create a new repo called _TaskReceiver.Plugins.YourGithubName_. After that head over to [the plugin repo](https://github.com/Kimmax/TaskReceiver.Plugin) and create a fork, clone to your workstation.
Now you open a shell and change into the fork clone/Plugins and add your plugin as a submodule here. Than you can fiire up your IDE, add reference to the Base Plugin and start working! When you are done commit and push your changes on your repo and if you would like to publish commit and push to your TaskReceiver.Plugin fork and open a pull request. Done!  
TL;DR:  
1. Create a new repo called _TaskReceiver.Plugins.YourGithubName_.  
2. Fork [the plugin repo](https://github.com/Kimmax/TaskReceiver.Plugin)  
Setup workspace:  
```
$> git clone https://github.com/YourGithubName/TaskReceiver.Plugin
$> cd TaskReceiver.Plugin/Plugins
$> git submodule add https://github.com/YourGithubName/TaskReceiver.Plugins.YourGithubName
```  
Do work inside _TaskReceiver.Plugin/Plugins/TaskReceiver.Plugins.YourGithubName_ (Add reference to TaskReceiver.Plugin, implement ITaskReciverPlugin!)  
Publishing:  
```
$> cd TaskReceiver.Plugin/Plugins/TaskReceiver.Plugins.YourGithubName
$> git commit -a -m "[Commit message]" && git push --all
$> cd TaskReceiver.Plugin/Plugins
$> git commit -a -m "Added TaskReceiver.Plugins.YourGithubName" && git push --all
```
Head over to [the compare page](https://github.com/Kimmax/TaskReceiver.Plugin/compare) and open a pull request.
Get approved → ??? → Profit.

### Contributing to the base server
1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D
