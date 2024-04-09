<h1>Monsters and Parts</h1>

`Monster` - script that is on an empty game object that contains a `Core`
`Core` - inherits from `Part`. Contains offsets for the other limbs to look for when placing them
`Part` - has stats for speed or damage etc. ... The `Monster` script looks in the hierarchy at all of these and then collates their values, so each part can have their own values
`MonsterSpawner` - accepts a list of parts it will use to randomly create a monster at an interval

EXAMPLE:
If you want to have a "Zombie" you could create an empty gameobject with a `Monster` script.
Then, in the Prefabs folder we have a Parts folder. Add a `Core` part to the Zombie.
You could put more parts under the core.

Alternatively, you could use the `MonsterSpawner` component on an empty game object. That script can accept an array of parts to use to randomly make monsters.
Even if you only use one set of parts, the `MonsterSpawner` can create just a zombie or just a skeleton instead of a hybrid, as long as you make multiple monster spawners.
