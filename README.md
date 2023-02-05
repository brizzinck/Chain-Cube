Goal: from the geometric primitives available in the Unity editor to create a prototype
of the game Chain Cube: 2048 3D merge game.
By pressing the screen, we fix the pressing and give the player the opportunity to
move the finger (left-right) to change the horizontal position of the cube, by raising
the finger from the screen we give the cube an acceleration N along the Z axis. Each
cube contains a value of 2x and starting from 2x ( 2, 4, 8, 16 etc.), based on the
value, the corresponding color is assigned in advance (2 - red, 4 - yellow, etc.).
Cubes with the same values are summed up - creating a whole cube, changing
color, value and getting a slight acceleration along the Y axis, and the number on the
cube is added to the total score in the center of the screen.
Connect Google Admob and display a test banner below/above. Every 10-20 shots
of the cube, display a test interstitial advertisement.
Criteria for evaluation:
1) Ability to expand in the future (adding new colors, values, possibly bonuses);
2) Using the capabilities of the engine (perhaps Unity physics, perhaps
Scriptable Objects, etc.);
3) Creativity of the solution;
Task to think: add a start screen with the “Play” button and 2 flags - RU / EN, by
clicking on which the language / text field “Play” changes to the language of the flag,
the value of the text field must be loaded from a JSON text file.
Result: build in *.APK file, ideally upload the code to your personal Git

https://user-images.githubusercontent.com/87083857/216843036-2991b042-e364-462d-8615-9c870f17ad90.mp4
