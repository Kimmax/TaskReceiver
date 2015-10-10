![Picture](ressources/header.png?raw=true)
# TaskReceiver
Welcome to the TaskReciever Repo!
You're here because Google brought you here, or you where just lurking around on Github, weren't you? Gotcha. Okay so let me tell what TaskReciever is.
TaskReciever is a small libary, written in C# which will open a server and waits for commands. Commands will be send in form of a simple HTTP Get request. Commands will be registered at startup and triggred by a speicifeid URL. If a command is triggered it task will be executed.
### Okay, but why?
Why you ask? I shall tell you, you fool!
The main aproch for this libary is to build an endpoint for the Android Tasker+AutoVoice combination. Using Tasker and AutoVoice togeteher will give you the possibility to control everything ony your phone via voice commands. "Ok Google, turn the music on" could start the music on your phone, coll huh? Why not make it even more cooler? Instead of playing the music from your phone you could play it on your stereo if you're at home. With the power of your Voice! And this is just the beginning. You can control everything with your voice, if you're computer can control it and now tell me what your computer can control? You just have to teach him! And with this project you can! You can programm your your commands in C# (for now, _all_ others are comming soon), add one method call to the server class and you're ready to go!

## Usage
For now you have to clone this repo and add a class named _CommandYOURCOMMANDNAME_ to _src/TaskReceiver.Frontend_.
Your command should inerhit _src/TaskReceiver.Base/Command.cs_. For example here is a simple echo command:
```c#
  class CommandEcho : Command
  {
    public CommandEcho(string trigger) : base(trigger) {}

    public override void Execute(List<Tuple<string, string>> param)
    {
      Console.WriteLine("CommandEcho: " + param[0].Item2);
    }
  }
```
Now all you have to do is to open up _src/TaskReceiver.Frontend/Program.cs_ and insert 
```C#
  server.RegisterCommand(new CommandEcho("/echo"));
```
after line 26.
Build, allow firewall and have fun!
## Contributing
1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D
