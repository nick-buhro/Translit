# NickBuhro.Translit.Tests.TestCase

This folder contain test cases.


## Folder structure

This folder contains test cases for all languages.
Test cases for specific language should be located in subfolder (subfolder name = target language).


## Files

All cases are separated into files of 2 types:

1. FullXX.txt
2. RoundXX.txt


### FullXX.txt

File with accurate test cases that contains 2 parts: cyrillic string and latin string.
So it could be separately tested cyrillic-to-latin and latin-to-cyrillic convertations.
File format:
	
	[Cyrillic value]
	[Latin value]
	
	[Cyrillic value]
	[Latin value]
	...

Example:
	
	Славься, Отечество наше свободное,
	Slav`sya, Otechestvo nashe svobodnoe,

	Братских народов союз вековой,
	Bratskix narodov soyuz vekovoj,

	Предками данная мудрость народная!
	Predkami dannaya mudrost` narodnaya!

	Славься, страна! Мы гордимся тобой!
	Slav`sya, strana! My` gordimsya toboj!


### RoundXX.txt

File with only cirillic part of test case.
Actually it can be any text file.

Test strategy: 

	var latin = Transliteration.LatinToCyrillyc(originalCyrillic, ...);
	var cyrillic = Transliteration.CyrillycToLatin(latin, ...);

	Assert.Eqauls(originalCyrillic, cyrillic);