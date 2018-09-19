# NickBuhro.Translit.Tests.Assets

This folder contains test cases which should be handled by different ways.

## Alphabet test cases

It is based on transliteration table from original standard.
It covers all letters for all languages.

Table is defined in tab-delimited file [Alphabet.txt](./Alphabet.txt).

## Exact test cases

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
	

## Round test cases

It should be file with cyrillic text.

Test strategy: 

	var latin = Transliteration.CyrillicToLatin(originalCyrillic, ...);
	var cyrillic = Transliteration.LatinToCyrillic(latin, ...);

	Assert.Eqauls(originalCyrillic, cyrillic);