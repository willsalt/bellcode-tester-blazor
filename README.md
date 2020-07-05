# Bell Code Tester (Blazor Webassembly)
Test your knowledge of British railway bellcodes, in your browser
## Background
Traditionally, on the British railway network from around the 1870s, safe-working messages about the passage of trains were sent from place to place by ringing single-stroke electric bells. Signallers were expected to memorise a long list of "bell codes", with meanings varying from routine ones such as "Is the line clear for the express?" (4 bells) to emergencies like "Train running away in the wrong direction" (2 bells, then 5, then 5 more).  Although most of the railway network has replaced this with "train describer" machines and other modern systems, there are some substantial stretches of route that are still operated this way.

## The Tool
This is a tool to help you learn these codes, written using Blazor Webassembly.  It simulates (at a very basic level) a "Key Token Instrument".  These are most often painted red, and connect pairs of locations (usually signalboxes).  Each has a brass plunger that rings the bell at the other location, and a telegraph needle which moves whenever the plunger at either location is pressed in.

This tool is based on [a Windows Forms tool I wrote a few years ago](https://github.com/willsalt/bellcode-tester) which has somewhat more features.  At present, this tool will give you the name of a bell code, such as "Call Attention" or "Train Entering Section", and wait for you to ring the code using the plunger.  When it thinks you have sent an entire code, it will tell you whether you're right or not, and if you weren't, what it thinks you did ring.  The Windows Forms version can also test your understanding of codes it plays to you, and lets you load in alternate code lists.  This tool currently has a single hard-coded list of bell codes, based on that used nowadays by the [Severn Valley Railway](https://www.svr.co.uk/), a heritage railway which bases its rule book on that historically used by the Great Western Railway and their successor, British Railways (Western Region).

## The Code
The tool is written in C# using Blazor Webassembly 3.2.0, and doesn't have any other dependencies.
