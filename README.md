# Karting-ML-Agents

### Opis
Za izradu karting utrke koristio sam jedan od najpopularnijih alata za
izradu igara, a to je Unity. Sama igra zamišljena je tako da se izvodi
sama, četiri kartinga se utrkuju na kreiranoj stazi. Kako bi se postigla
mogućnost izvođenja bez potrebe za korisnikom implementirao sam
ML-Agente. Svaki karting je jedan agent čije se ponašanje mora trenirati
kako bi se agent znao što brže i bolje kretati po stazi. Kretanje kartinga
implementirano je pomoću kontroler skripte koristeći programski jezik
C#. Karting mora znati gdje se nalazi na stazi, zbog toga su cijelom
stazom postavljene kontrolne točke koje mogu detektirati kada je
karting prošao kroz njih. Tip strojnog učenja koji je korišten je strojno
učenje s potporom, a njegova glavna značajka je mogućnost zapažanja i
dodjeljivanja nagrada. Zapažanje se odvija preko senzora koji su dodani
na karting, a nagrada se dodjeljuje prolaskom kroz svaku kontrolnu
točku. Nakon postavljenih svih elemenata kako bi igra funkcionirala
preostalo mi je treniranje agenata. Treniranje sam provodio pomoću
Python API-a koji je sastavni dio ML-Agenata koje je potrebno instalirati
unutar projekta. Nakon višesatnog treniranja agenti su spremni za
utrkivanje.


