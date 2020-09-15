# Minecraft Map Manager #

A tool to create, delete, and edit maps on a Minecraft world, and easily convert images to map art.

## Compiling ##

## How it works ##

Minecraft stores maps in the data directory of each Minecraft save. Each map is stored in an NBT file with the name map_[id].dat. The idcounts.dat file keeps a record of the latest map ID.

Each colour is stored in the map file statically; it does not get loaded everytime. Hence the reason why you need to reload the chunks to update a map.

Because of this, map art can be stored as colours in the map file, without the actual terrain needing to exist. Minecraft Map Manager simply converts an image into a limited colour palette with some algorithms, and writes this data to the map file.

Since Minecraft Snapshot 19w02a (1.14), maps can be locked, meaning there is no risk of the map being overwritten if the chunks are reloaded.

## Usage ##

## Note ##

I wrote this tool in Visual Basic since I have to do it in college for some reason. It's not really of any use to me since I don't use Windows, but I'm planning to write an NBT library and LevelDB wrapper in C++ sometime, then make a cross-platform toolbox application that can do a plethora of different Minecraft related things.