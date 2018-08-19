# NLP-NER-CSharp

Named Entity Recognition using C#

## Run the app
For this app to run, restore nuget packages and build.

This is a simple application to demonstrate the Named Entity Recognition using Stanford's Natural Language Processing library 'Stanford.NLP.CoreNLP'

## XML Deserialization
This application features deserializing the 'xml' output generated and allows to perform LINQ operations. The corresponding models are present in Models directory.

The final output for the sample input document demo.txt file is shown below

(The contents of demo.txt file are just for educational purposes and are obtained from https://economictimes.indiatimes.com/ashok-leyland-ltd/stocks/companyid-14041.cms on 18/AUG/2018 )
## Output

    -----------Location-----------
    India
    -----------Organization-----------
    Ashok
    Leyland
    Ltd.
    Ashok
    Leyland
    Ltd.
    Spare
    Parts
    &
    Others
    Engine
    &
    Gensets
    Other
    Services
    Hinduja
    M
    S
    Krishnaswami
    &
    Rajan
    -----------Person-----------
    Palmer
    Balaji
    Rao
    Maria
    Alapont
    Asher
    Shroff
    Khanna
