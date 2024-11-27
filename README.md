# CGCourseProject
 By Daniel Barbier - 100820942 <br>
 
 Controls : <br>
 WASD to move <br>
 Mouse to look around <br>
 Left Mouse to Attack <br>
 Spacebar to Jump<br>
 Left Mouse click to shoot <br>
 Left mouse click X3 to Heavy Attack <br> 

 ## Toon Shader
![image](https://github.com/user-attachments/assets/03c00363-ff09-4007-b48d-c7ccfa1c7464)

Dot product of the Diffuse Lighting and the Light Direction<br>
It pulls the toon ramp and shades it based on the values it has<br>



 ## Surface Shader
 ![image](https://github.com/user-attachments/assets/0d153fca-f8ea-40fa-9987-dddfb7ea70d6)

 Standard Lambert Diffuse Equation:
 Diffuse = Diffuse Direction cos θ.


 ## Colour Correction
 ![image](https://github.com/user-attachments/assets/edb058bf-7314-4376-ae8f-381fec26f676)
 The colour correction uses a LUT map, this map can be edited to "correct" colours without having to edit materials and shaders alike separately,
 Since there is suppose to be grim atmosphere it is on the more crimson red side<br>


## Glass Shader
<img width="459" alt="GlassShader" src="https://github.com/user-attachments/assets/acb34d8d-01bd-4589-818b-ce463731f599">
The Glass Shader was made by using a fragment shader and a vertex shader it takes the vertices and puts them into clip space from world space, the fragment shader then positions it, and it also tints whatever is behind it based on wether something is in front of it or not. It fits this project as the scenario is set in a building<br>

## Muzzle Flash

<img width="395" alt="muzzleFlash" src="https://github.com/user-attachments/assets/769c4893-329c-4e23-8120-5c8634fdd5d9">

The muzzle flash effect is made using two planes crossed into each other, This method is called carboarding where you use two planes instead of a full 3D model<br>
Commonly used to save on performance such as grass and faraway trees. It fits the scenario as it looks stylized and it saves on performance for big flashy moves<br> such as the heavy attack.<br>

## Scrolling Texture
<img width="362" alt="neon" src="https://github.com/user-attachments/assets/08077806-7541-4e0f-a1ac-e04015594c92">
The Scrolling texture is used here to indicate where the player is suppose to go, it was made by having the texture map scroll with time, it can either go on the x axis<br>
or the y axis<br>





 

 
