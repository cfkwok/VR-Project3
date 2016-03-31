# VR-Project3: Mount Everest
In this project, collective data on Mount Everest is shown to the users in virtual reality.

### Source Code and APK
[Android APK and Source Code](https://drive.google.com/file/d/0B4r_loZFJqdya1o0b0RsVDBydXc/view?usp=sharing)

### Authors
[Fai Kwok](https://github.com/cfkwok)  
[Timothy Wagner](https://github.com/Atonement100)  
[Tonny Xie](https://github.com/tonny-12)  

### YouTube Video
[Demo](https://youtu.be/C4dzIEDLk_Y)

### Website
http://cfkwok.github.io/VR-Project3

### Screenshots
![image](https://cloud.githubusercontent.com/assets/13974892/14173579/ab6cc0d2-f70c-11e5-98d0-337685971275.png)
![image](https://cloud.githubusercontent.com/assets/13974892/14173604/ddd4a45e-f70c-11e5-8be2-d0f96647a9e7.png)
![image](https://cloud.githubusercontent.com/assets/13974892/14173618/f74040b0-f70c-11e5-990e-17ccc2655566.png)
![image](https://cloud.githubusercontent.com/assets/13974892/14173639/150277a8-f70d-11e5-9b4e-6313ee28aa53.png)
![image](https://cloud.githubusercontent.com/assets/13974892/14173653/3f17e140-f70d-11e5-9cbb-2cbeb3befa74.png)
![image](https://cloud.githubusercontent.com/assets/13974892/14173912/f3fbd98a-f70e-11e5-8107-160874aeb9a2.png)
![image](https://cloud.githubusercontent.com/assets/13974892/14173925/0121d72c-f70f-11e5-89a5-fcf89bda866b.png)
![image](https://cloud.githubusercontent.com/assets/13974892/14173934/104feaea-f70f-11e5-9396-e2b6e7605e80.png)

### Motivation and Explanation
Presented with the idea of representing data in VR, our group came to plan the design of an interesting crossroads of data sources. The Everest VR experience we have designed allows users to live in a combination of various data. First, and most obvious, is the actual terrain that users will walk on. The terrain is derived from heightmap data which has been imported and rebuilt in-engine to be explored first hand. For the sake of attempting to keep people within typically traversed trails, we have included in a heads-up display a couple bits of information, including the current trail and a compass to direct the user to pre-defined waypoints, which updates to point to the subsequent waypoint as you arrive at each. Additionally, we have included, to augment the experience, accurate time and weather data from Everest. Information about the current weather is also included in the heads-up display, including time, wind speed, and rain/snow intensity. All weather is additionally represented visually, including implementation of a day-night cycle as well as independent snow and rain systems that trigger according to the recorded intensity of the weather. All time (and its corresponding weather) data is represented on a minute-by-minute resolution, at a rate of one minute simulated per one second of real time. Finally, we have also included in the experience, a small number of mini-episodes representing common fatality data.

To allow users to experience more data in a compact span of time, we have also provided a number of manipulation tools to help them move through the data. Implemented are “teleports,” some of which allow users to physically teleport to a subsequent or previous waypoint. Other features of the teleport system allow users to teleport through time either forward or backward (while remaining in the same location), both on an hourly resolution and by larger segments of time, shifting users to either morning, evening, overnight time slots. Following either style of teleport, users will instantly resume the progression of the experience. All of these different types of teleports can be combined in a variety of ways to experience all permutations of each type of data we have included in the Everest VR project.


### Insight Objective
The compiled data we have on Mount Everest will give the users an experience of what the climate one should expect at different elevations, the dangers and fatalities that occurred in the ascent, and easy-to-access campsites along the North-Col and South-Col routes of Everest within virtual reality. The use of VR leverages a better understanding of the altitudes of campsites along the routes, clearer insight of the weather expressed in that setting, and an immersed scare about the dangers of performing the ascent.

### Gaining Inisght into the Data
**Predict two major insights participants will gain:**  
1. The beauty and magnitude of Mount Everest.  
2. The difficult journey to the top of Mount Everest.

**Person 1:**  
What he/she knows about Everest  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "Highest peak in the world?"  
Insights gained after VR experience  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "Mount Everest highest peak is approximately 24000-25000 feet"  

**Person 2:**  
What he/she knows about Everest  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "Tallest mountain in the world."  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "Many people die climbing it."  
Insights gained after VR experience  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "I felt like I was standing at the peak of Mount Everest."  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "I learned that there were only 5000 to reach the peak."  

**Person 3:**  
What he/she knows about Everest  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "Huge mountain of snow."  
Insights gained after VR experience  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "47 people died from avalanche."  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "Beautiful scene at the top of the mountain."  

**Kennedy Simulator Sickness Questionnaire**  

|                          | [1] | [2] | [3] |
|--------------------------|-----|-----|-----|
| General Discomfort       | 1   | 2   | 1   |
| Fatigue                  | 0   | 1   | 0   |
| Boredom                  | 1   | 1   | 1   |
| Drowsiness               | 0   | 0   | 0   |
| Headache                 | 0   | 2   | 0   |
| Eyestrain                | 0   | 1   | 0   |
| Difficulty Focusing      | 0   | 0   | 0   |
| Salivation Increase      | 0   | 0   | 0   |
| Sweating                 | 0   | 0   | 0   |
| Nausea                   | 0   | 0   | 0   |
| Difficulty Concentrating | 0   | 0   | 0   |
| Mental Depression        | 0   | 0   | 0   |
| "Fullness of the Head"   | 0   | 0   | 0   |
| Blurred Vision           | 0   | 0   | 0   |
| Dizziness Eyes Open      | 0   | 0   | 0   |
| Vertigo                  | 0   | 0   | 0   |
| Visual Flashbacks        | 0   | 0   | 0   |
| Faintness                | 0   | 0   | 0   |
| Aware of Breathing       | 0   | 0   | 0   |
| Stomach Awareness        | 0   | 0   | 0   |
| Loss of Appetite         | 0   | 0   | 0   |
| Increased Appetite       | 0   | 0   | 0   |
| Desire to Move Bowels    | 0   | 0   | 0   |
| Confusion                | 0   | 0   | 0   |
| Burping                  | 0   | 0   | 0   |
| Vomiting                 | 0   | 0   | 0   |
| Total                    | 2   | 7   | 2   |

Before going through the experience, all three people ([1], [2], [3]) have very common knowledge of Mount Everest's immense size. After the experience, our prediction of, "The beauty and magnitude of Mount Everest." was the more common insight the three individuals grasped. [1] gained insight on what the elevation of Mount Everest is at the peak, and [2] and [3] reported on the beautiful scenery of the mountain's peak. Although our second prediction, "The difficult journey to the top of Mount Everest.", was not as common, [2] and [3] alluded to the "difficult journey". [2] used the word "only" to describe his insight on how many people successfully ascended to the top of Mount Everest. This can be interpereted as his surprise to the fewer number of summiters than he expected. [3] learned how many people died from an avalanche, but simply reported the information rather than seeing it as part of the difficult journey.

The simulator sickness questionarre resulted in fairly resonable results. [2] had a much higher total than the other two participants because the Google Cardboard did not fit comfortably on him which probably resulted in headache and eyestrain. [1] and [3] did report a discomfort in wearing the headset, but this did not cause any notable sickness to them. A major factor in these results are most likely due to the weight of the phone being used in the Cardboard. The phone is slightly larger than most phones causing the Cardboard to tilt forward and would rely only on the user's nose to support much of the weight.

### Research
[Summiter Data](http://www.8000ers.com/cms/download.html?func=startdown&id=152)  
[Fatality Data](http://www.8000ers.com/cms/en/download.html?func=fileinfo&id=171)  
[Weather Data](http://www.mountain-forecast.com/peaks/Mount-Everest/forecasts/8850)  

### Assets & Resources
[Rain Maker Asset](https://www.assetstore.unity3d.com/en/#!/content/34938) by Digital Ruby, LLC  
[Day/Night Cycle Tutorial](https://www.youtube.com/watch?v=h5GFoI38DOg) by Glen Rhodes  
[Tents Model](https://www.assetstore.unity3d.com/en/#!/content/21461) by VIS Games  
[Breath Sound](https://www.freesound.org/people/The%20Baron/sounds/98397/) by The Baron  
[Mount Everest Heightmap](http://terrain.party/) by terrain.party  
[Heightmap Tutorial](https://www.youtube.com/watch?v=-vyNbalvXR4) by HelloWorldStudios  
[Humanoid Models](https://www.mixamo.com/) by mixamo  

