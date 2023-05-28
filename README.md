# Minecraft Map Manager #
 
 ## ⚠️ Discontinued
 
Development for this tool has been continued in [here](github.com/ryanbester/minecraft-map-manager). I wasn't able to easily upgrade the legacy VB code so I decided to rewrite the tool in Go.

A tool to create, delete, and edit maps on a Minecraft world, and easily convert images to map art.

## Compiling ##

## How it works ##

Minecraft stores maps in the data directory of each Minecraft save. Each map is stored as an NBT file with the name map_[id].dat. The idcounts.dat file keeps a record of the latest map ID.

Each colour is stored in the map file statically; it does not get calculated everytime from the actual blocks. Hence the reason why you need to reload the chunks to update a map.

Because of this, map art can be stored as colours in the map file, without the actual terrain needing to exist. Minecraft Map Manager simply converts an image into a limited colour palette with some algorithms, and writes this data to a map file.

Since Minecraft Snapshot 19w02a (1.14), maps can be locked, meaning there is no risk of the map being overwritten if the chunks are reloaded.
