# Top Down 2D Game Framework

This repository contains progress on creating a framework for a top down 2D game.

![](preview/20200410.gif)

## Features

Currently, this is just a brain dump of all the features/things I want to have working in here before actually trying to develop something with substance.

- [x] Full Movement
- [x] Collision System
- [x] Camera Movement (follow player)
- [x] Transitioning (doors to buildings, movement to new parts of map)
    - [x] Scene Transitioning 
    - [x] Local Transitioning (teleporting to other parts of the scene, saves small buildings needing to be in separate scenes)
- [ ] NPCs/Conversation
- [ ] Inventory System (not looking forward to this, gonna be a biggie)
- [ ] Character Customisation
- [ ] Combat System
- [ ] Menu System
- [ ] Save States
- [ ] Light System
    - [ ] Day/Night Cycle
    - [ ] Local Lighting (torches, etc)
- [ ] Anything Else I Bloody Well Feel Like Adding

## Thoughts/Things to Change

_Note: These things could be bugs or issues that are tracked via GitHub but it's quicker and easier to manage them through here for now. Things will be deleted when no longer relevant/recent._

- The decorations layer of tilemaps does not interact properly with the layering (as this is determined from y axis location, which is shared for the tilemap). Find a way of fixing the depth with tilemaps or just concede that decorations that require proper depth (like torches) will need to be separate prefabs (makes sense as torches will most likely have some independent lighting functionality going forwards)
- ~The camera movement currently uses the bounds of a large Box Collider on the world, this feels clunky and leads to phantom collisions as anything inside the box is technically colliding with it. Change this to something else, perhaps intelligently working out the bounds of the sprites on the edge layer?~
    - This has been addressed by utilising the collision with the map bounds collider to intelligently set which bounds the player is currently within. Allowing the player object to move between scenes and spaces whilst maintaining proper camera tracking functionality.
- ~Instead of manually setting the position to move players to for building/scene transitions, instead store some sort of global variable that has the "last used" door/movement location. This objects co-ordinates can then be used for spawning the player back to the original point.~
    - Seems somewhat pointless as co-ordinates are only needed for scene transitions, local transitions use the center of the box collider.
- ~Due to the starting scene having a player in it, there's a duplication glitch when returning to the original map. This can be addressed by (after adding some sort of global controller above) having some check for an existing player and spawning in if not present (this should spawn a player on first load of the game and then never again as we simply move the game object around).~
    - This has been addressed by adding the GameManager persistent object that checks for an existing player and spawns one if one is not present.

## Credit

### Assets

Character:
- ["Sharm's Tiny 16 Character Sprites - Expanded" by Sharm, withthelove and Evert](https://opengameart.org/content/tiny-16-expanded-character-sprites)

World Assets:
- ["Roguelike pack" by Kenney Vleugels for Kenney.nl](https://www.kenney.nl/assets/roguelike-rpg-pack) 
- ["Roguelike Indoors" by Kenney Vleugels for Kenney.nl](https://kenney.nl/assets/roguelike-indoors)
- ["Roguelike Cave" bt Kennel Vleugels for Kenney.nl](https://kenney.nl/assets/roguelike-caves-dungeons)

Fonts:
- ["Retro Gaming" by Daymarius](https://www.dafont.com/retro-gaming.font)

### Tutorials/Assistance

This wouldn't have been possible for me to learn without the help of the incredible tutorial series by CouchFerret, [available here](https://www.youtube.com/playlist?list=PLM83Z6G5iM3k48356VU6e-oXWl_uwwq4F).

Also, big thanks to [DuckDuckGo](https://duckduckgo.com/) and the general existence of the Internet.
