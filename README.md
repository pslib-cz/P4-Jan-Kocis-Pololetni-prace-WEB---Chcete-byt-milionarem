# Kdo chce být milionářem?

Cílem práce je vytvořit ASP.NET aplikaci, která bude:
ukládat data do databáze
umožní registrovat nové uživatele
obsahuje funkční přihlašování uživatelů
bude funkční
logika aplikace bude uložena v service, ta bude mít přístup k EntityFrameworku přes Dependency Injection
pagemodely budou samozřejmě také používat service

Tématem práce je známá hra "Chcete být milionářem".

Takže se po identifikaci uživatele budou objevovat otázky z databáze a k nim přidělené odpovědi.
Při správné odpovědi hráč pokračuje, při špatné končí.
Hra bude rozdělena na 3 stupně složitosti - 
vždy po 5 otázkách se složitost zvyšuje a vybírají se těžší otázky, tedy celkem budou 3 databáze s otázkami -> 
každá podle složitosti + ke každé 4 odpovědi z nichž bude jen 1 správná. Když odpoví hráč správně, 
tak pokračuje dál a při špatném zodpovězení hra končí a jede odznovu. Když hráč zodpoví všechny otázky správně, 
tak na konci se vypíše něco jako "zvítězil jste", skóre se vynuluje a hra začíná odznovu.

DATABÁZE

USER - Identita, ověření uživatele který hraje, váže se na něj jaké kolo hry hraje a pomocí toho se buď 
	zvýší náročnost nebo se bude zjišťovat, kterou otázku již zodpověděl, aby se neopakovala
Otázka ve hře - zjištění, které otázky již byly zodpovězeny
Otázka - Otázka obsahující nějaké unikátní ID, text a náročnost podle toho, které kolo se bude objevovat
Odpověď - Odpověď obsahující unikátní ID a ID pojící se k otázce, budou 4 k jedný otázce - jen 1 správná, obsahuje text
	a zjištění, zda se jedná o správnou odpověď či špatnou

<navrhDatabaze.PNG>

