# DIG4778C-Lab8

Ricky Elia: For the object pool I made a list called objectPool and then I would instantiate 30 of them on start and set them inactive.
When I press spacebar it checks the list and grabs the current variable in the list, it then checks if it's active and if it's not, sets it active and shoots it upward.

Ricky Elia: For the transformSaver I Have 4 scripts. DataPersistenceManager is a singleton class that manages saving and loading, the other is an interface that references the managers save and load functions, FileDataHandler creates and serializes the Json file based off of information from TransformSaver, and then transformsaver stores a default value when there is no save file to be found.
