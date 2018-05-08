Installasjonsveiledning
=======================

Arkade 5
********

**Skrivebordsapplikasjon for Windows**

Installer .NET
~~~~~~~~~~~~~~

For å kjøre Arkade 5 må .NET Framework (minimum versjon 4.5.2) være installert.

`Last ned siste versjon av .NET Framework <https://www.microsoft.com/net/download/windows/run>`_


Installer Arkade 5 
~~~~~~~~~~~~~~~~~~

`Last ned siste versjon av Arkade 5 <https://github.com/arkivverket/arkade5/releases/latest>`_ - Velg filen Arkade5-<versjon>.msi

Start installasjonen ved å dobbeltklikke den nedlastede msi-filen.

.. image:: img/NedlastningerFilViser.png

**Merk: Windows Smart Screen advarsel**
Den følgende advarselen vil vises om Windows-maskinen har "Windows Smart Screen" satt på (Windows 10).

.. image:: img/WinSmartScreenWarning.png

* Klikk på "Mer info"
* Klikk "Kjør likevel"


**Følg installasjonsveiviseren og aksepter alle de foreslåtte installasjonsvalgene.**


Kjør programmet
~~~~~~~~~~~~~~~
.. image:: img/RunTool.png

* Start -> Alle apper
* Finn "Arkade 5" i applikasjons-listen
* Klikk på "Arkade 5" for å kjøre programmet

Avinstallasjon av programmet (Windows 10)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
.. image:: img/Uninstall_02.png

* Klikk Start -> Instillinger -> System -> Apper og funksjoner
* Velg "Sorter etter installasjonsdato"
* Velg "Arkade" i listen over installerte programmer
* Klikk "Avinstaller"
* Klikk "Avinstaller" igjen i nytt vindu
* Klikk "Ja" på Brukerkontokontroll-advarselen fra Windows

__________________________________________________________________________

Arkade 5 CLI 
************

**Kommandolinjegrensesnitt for Linux, macOS og Windows**

__(df)__

Installer .NET
~~~~~~~~~~~~~~

For å kunne kjøre Arkade 5 CLI må .NET runtime være installert på maskinen.

Windows:
.NET Framework > versjon 4.5.2

Linux/macOS/Windows:
.NET Core > versjon 2.0

.NET Core må være installert for å kunne kjøre Arkade 5. Dette kan lastes ned her_.

.. _her: https://www.microsoft.com/nb-no/download/details.aspx?id=42643


Installer Arkade 5 CLI
~~~~~~~~~~~~~~~~~~~~~~

`Last ned siste versjon av Arkade 5 CLI <https://github.com/arkivverket/arkade5/releases/latest>`_ - Velg filen Arkade5CLI-<versjon>.zip

Pakk ut den nedlastede zip-filen til der Arkade ønskes kjørt fra. Ingen ytteligere installasjon er nødvendig.

(Det spiller ingen rolle hvor i filsystemet Arkade CLI kjøres fra; plassering for alle inn- og ut-data velges som parametre ved kjøring)


Kjør Arkade 5 CLI
~~~~~~~~~~~~~~~~~

`Se brukerveiledning Arkade CLI <Brukerveiledning.html#arkadecli>`_

Avinstaller Arkade 5 CLI
~~~~~~~~~~~~~~~~~~~~~~~~

* Slett katalogen Arkade5CLI-<versjon>
* Slett eventuelle gjenværende systemlogger

*Mindre enn 1 uke gamle system- og feillogger slettes ikke automatisk etter kjøring.* `Les mer ... <Brukerveiledning.html#prosesseringsomrade>`_
