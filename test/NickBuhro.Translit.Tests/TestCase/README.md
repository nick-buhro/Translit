# NickBuhro.Translit.Tests.TestCase

This folder contain test cases for all languages.
Test cases for specific language should be located in subfolder (subfolder name = target language).

All cases are separated into files of 2 types:

1. FullXX.txt
2. RoundXX.txt


## FullXX.txt

File with accurate test cases.

One file can contain many test cases. 
Test cases should be separated by one or more empty lines.

One test case should be represented by 2 lines: cyrillic and latin values.
Values should be separated by new line (one value = one line).

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
	

## RoundXX.txt

It should be file with cyrillic text.

Test strategy: 

	var latin = Transliteration.CyrillycToLatin(originalCyrillic, ...);
	var cyrillic = Transliteration.LatinToCyrillyc(latin, ...);

	Assert.Eqauls(originalCyrillic, cyrillic);