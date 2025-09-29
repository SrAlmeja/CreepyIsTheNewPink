=== start ===
#checkpoint:start

Pasaba de la medianoche cuando dejé la interestatal en dirección al parque de diversiones que tanto amé en mi infancia. Los truenos y relámpagos iluminaban el cielo y una fuerza irresistible me atraía a ese lugar.

#play:truenos

Había tenido pesadillas inexplicables con este lugar “mágico”, con una misteriosa puerta de metal y las tenebrosas risas de niños que me despertaban de golpe, dejando las sábanas empapadas en sudor.

El cansancio acumulado de muchas noches sin dormir pesaba sobre mis párpados, así que cerré los ojos un segundo.

¿Volver a abrir los ojos?
+ si
    ->llegada
+ no
 -> infarto
 
=== infarto ===
¡Oh, no! ¡Moriste de un infarto!
#death
-> END

=== llegada ===
#checkpoint:llegada
Cuando los volví a abrir, ya estaba frente al parque.

Bajé de mi auto y comencé a caminar. De pronto, una rata pasó corriendo frente a mis pies.
#play:rata

“No sé para qué vine aquí. Como si esto pudiera resolver algo”.

Las palabras se ahogaron en mi garganta, eclipsadas por el sonido chirriante de la reja de hierro forjado oxidada que se abría lentamente ante un golpe de viento.
#play:chirrido

¿Entrar al parque?

 + No
 -> pena_terrible
 
 + Si
 -> entrando
 
 === pena_terrible ===
 ¡Oh, no! ¡Moriste alcanzado por un meteorito!
 #death
-> END
 
===entrando===
El silencio me golpeó con el peso de una losa, una quietud antinatural, donde hasta el rugido del trueno parecía amortiguado.

La atmósfera era espesa y pegajosa, con un olor dulce y rancio a algodón de azúcar en descomposición mezclado con madera húmeda y algo más, algo mineral y frío.
#play:void

La entrada que alguna vez había brillado con luces de neón y colores vibrantes, ahora era solo una silueta espectral; la pintura se había desconchado en grandes parches, dejando al descubierto el metal corroído como una herida.

¿Explorar el parque?
+ Si
-> centro_parque
+ No
-> rompete_el_cuello

===rompete_el_cuello===
¡Oh, no! ¡Te tropezaste y te rompiste el cuello!
 #death
-> END

===centro_parque===
#checkpoint:centroparque
Avancé con cautela por el camino principal y llegué al centro del parque.
#play:steps

A la izquierda hay un carrusel. Ya no gira, las inclemencias del clima y el paso del tiempo habían transformado sus caballos en algo grotesco.

A la derecha hay una hilera de juegos de feria. La lona de los puestos está desgarrada y se golpea suavemente con el viento. Aquí hay un juego de tiro al blanco y necesitas balines para jugar.

¿Quieres ir al carrusel o al tiro al blanco?
+ Carrusel.
-> carrusel
+Juegos de feria.
-> juegos

===carrusel===
#checkpoint:carrusel
#play:wind

Congelados en pleno galope, con sus ojos de cristal turbios y sus correas de cuero podridas colgando como babas. El eje central, oxidado y mohoso, parecía un altar a una alegría olvidada.

Te agachaste y encontraste unos balines en el suelo.

¿Quieres guardarlos en tu bolsillo e ir a explorar los juegos de feria?
+ Sí
-> regreso
+ No
-> viejo

===viejo===
Te levantaste demasiado pronto y te dio el soponcio.
 #death
-> END

===regreso===
Vamos al otro lado.
-> juegos

===juegos===
#checkpoint:juegos
#play:wind
Los pequeños patos de metal amarillo, están inmóviles y oxidados, a medio camino de sus carriles. Están cubiertos de una pátina verdosa, como si hubieran emergido de aguas profundas.

Alrededor de la estructura cuelgan los premios, son peluches gigantes, osos descoloridos, conejos con ojos descosidos me observan. Sus bocas de hilo, antes sonrientes, ahora parecían muecas de dolor.

“Cuando era niño yo ganaba muchos premios, debí venir con ella cuando aún había oportunidad y ver su cara iluminada mientras abrazaba uno de esos osos de peluche”.

¿Quieres usar los balines para jugar tiro al blanco?
+ Sí
-> peluche
+ No
-> culiacanazo

===culiacanazo===
¡Oh, no! ¡Perdiste todas tus vidas!
 #death
-> END

===peluche===
#checkpoint:peluche
¡Ganaste! Elige un premio.

+ Erizo.
-> erizo
+ Slenderman.
-> slenderman
+ Perro.
-> perro

===erizo===
Había tres juguetes que no reconocía: Un erizo azul con sonrisa diabólica, demasiado ancha, demasiado afilada, se extendía de oreja a oreja, revelando dientes que no eran de tela, sino pequeñas agujas blanquecinas, como si la carne que alguna vez tuvo se hubiera vuelto hueso. Esta sonrisa no denotaba alegría, sino una satisfacción sádica.

El peluche tiene un cierre.
¿Quieres abrir el cierre?
+ Sí
-> llave
+ No
-> peluche_asesino

===peluche_asesino===
¡Oh, no! El peluche cobró vida, te atacó y moriste.
 #death
-> END

===llave===
Encontraste una llave oxidada.
-> explorar

===slenderman===
Un muñeco sin rostro y cuerpo alargado que vestía un traje negro. Lo más escalofriante era la ausencia de un rostro. Donde deberían estar los ojos, la nariz o la boca, solo había una superficie lisa y pálida, un lienzo en blanco que invitaba a la mente a proyectar sus peores miedos.

El peluche tiene un cierre.
¿Quieres abrir el cierre?
+ Sí
-> llave
+ No
-> peluche_asesino

===perro===
Un perro con un tazón de cereal y una cuchara. A primera vista, parecía un juguete inocente, sostenía el tazón y la cuchara, demasiado grande para él, con sus patas delanteras. Pero algo pasaba si lo mirabas de cerca, sus ojos, dos grandes botones negros, te miraban con una fijeza perturbadora y sin emoción

El peluche tiene un cierre.
¿Quieres abrir el cierre?
+ Sí
-> llave
+ No
-> peluche_asesino

===explorar===
¿Seguir explorando el parque?
+ Sí
-> palomitas
+ No.
-> socavon
===socavon===
¡Oh, no! ¡Se abre un socavón bajo tus pies, caes y mueres!
 #death
-> END

===palomitas===
Necesitaba llegar al centro del parque, pero la ruta principal estaba bloqueada por un carrito de palomitas volcado que despedía un vapor enfermizo y débil.

Esta historia continuara?...

#victory
-> END