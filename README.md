
# Client Side Documentation

## Introduction
The client-side code is responsible for collecting sensor data and transmitting it to the server using various protocols. It includes protocols for communication and sensor implementations for data generation.

### Amqp.cs
This class implements the AMQP (Advanced Message Queuing Protocol) protocol for data transmission. It utilizes the RabbitMQ client library to establish a connection to the specified AMQP broker. The `Send` method sends sensor data as messages to a predefined queue.

### IProtocolInterface.cs
This interface defines the contract for protocol implementations. It requires a `Send` method for sending data along with the sensor type.

### VirtualSpeedSensor.cs
This class represents a virtual speed sensor, generating random speed values. It implements the `ISpeedSensorInterface` and `ISensorInterface` interfaces. The `GetSpeed` method generates a random speed value, and the `ToJson` method serializes the speed value to JSON format. The `GetSlug` method returns the sensor type.

### ISpeedSensorInterface.cs
This interface defines the contract for speed sensor implementations. It requires a `GetSpeed` method for retrieving speed values.

### ISensorInterface.cs
This interface defines the contract for sensor implementations. It requires `ToJson` and `GetSlug` methods for converting sensor data to JSON format and retrieving the sensor type, respectively.

### Speed.cs
This class defines the `Speed` value object, encapsulating an integer speed value.

### Program.cs
This is the main entry point of the client application. It instantiates sensors, defines the communication protocol (AMQP in this case), and continuously sends sensor data to the server.

## Communication Channel
The client-side code communicates with the server-side code via the specified protocol (AMQP in this case). The `Amqp` protocol implementation sends data to the AMQP broker specified by the host name, virtual host, username, and password. The server-side code, acting as a receiver, listens for messages on the predefined queue.

---

# Codice Lato Client

## Introduzione
Il codice lato client è responsabile della raccolta dei dati dai sensori e della loro trasmissione al server utilizzando vari protocolli. Include protocolli per la comunicazione e implementazioni dei sensori per la generazione dei dati.

### Amqp.cs
Questa classe implementa il protocollo AMQP (Advanced Message Queuing Protocol) per la trasmissione dei dati. Utilizza la libreria client RabbitMQ per stabilire una connessione al broker AMQP specificato. Il metodo `Send` invia i dati del sensore come messaggi a una coda predefinita.

### IProtocolInterface.cs
Questa interfaccia definisce il contratto per le implementazioni del protocollo. Richiede un metodo `Send` per l'invio di dati insieme al tipo di sensore.

### VirtualSpeedSensor.cs
Questa classe rappresenta un sensore di velocità virtuale, che genera valori casuali di velocità. Implementa le interfacce `ISpeedSensorInterface` e `ISensorInterface`. Il metodo `GetSpeed` genera un valore casuale di velocità e il metodo `ToJson` serializza il valore di velocità nel formato JSON. Il metodo `GetSlug` restituisce il tipo di sensore.

### ISpeedSensorInterface.cs
Questa interfaccia definisce il contratto per le implementazioni del sensore di velocità. Richiede un metodo `GetSpeed` per recuperare i valori di velocità.

### ISensorInterface.cs
Questa interfaccia definisce il contratto per le implementazioni del sensore. Richiede i metodi `ToJson` e `GetSlug` per convertire i dati del sensore nel formato JSON e recuperare il tipo di sensore, rispettivamente.

### Speed.cs
Questa classe definisce l'oggetto valore `Speed`, incapsulando un valore di velocità intero.

### Program.cs
Questo è il punto di ingresso principale dell'applicazione client. Istanzia i sensori, definisce il protocollo di comunicazione (AMQP in questo caso) e invia continuamente i dati del sensore al server.

## Canale di Comunicazione
Il codice lato client comunica con il codice lato server tramite il protocollo specificato (AMQP in questo caso). L'implementazione del protocollo `Amqp` invia dati al broker AMQP specificato dal nome host, dal virtual host, dal nome utente e dalla password. Il codice lato server, agendo come ricevitore, ascolta i messaggi sulla coda predefinita.

---

# Server Side Documentation

## Introduction
The server-side code is responsible for receiving sensor data transmitted by client applications and processing it. It includes components for message reception, data decoding, and storage in a database.

### RabbitMQReceiver.cs
This class represents a receiver for handling messages received via the RabbitMQ message broker. It connects to the broker, starts consuming messages from the specified queue, and processes incoming data.

### SensorData.cs
This class represents the data received from sensors. It includes information such as the sensor topic ID, speed value, and timestamps indicating when the data was sent and received.

### SensorRepository.cs
This class is responsible for interacting with the database to store sensor data. It includes methods to insert sensor data into the database asynchronously.

### Program.cs
This is the main entry point of the server application. It initializes the Rabbit

MQ receiver, starts receiving messages from the specified queue, and handles incoming data.

## Communication Channel
The server-side code communicates with the client-side code via the specified protocol (AMQP in this case). The `RabbitMQReceiver` class listens for messages on the specified queue and processes them accordingly, storing sensor data in the database.

---

# Codice Lato Server

## Introduzione
Il codice lato server è responsabile della ricezione dei dati dai sensori trasmessi dalle applicazioni client e del loro trattamento. Include componenti per la ricezione dei messaggi, la decodifica dei dati e l'archiviazione in un database.

### RabbitMQReceiver.cs
Questa classe rappresenta un ricevitore per gestire i messaggi ricevuti tramite il broker di messaggistica RabbitMQ. Si connette al broker, inizia a consumare messaggi dalla coda specificata e elabora i dati in ingresso.

### SensorData.cs
Questa classe rappresenta i dati ricevuti dai sensori. Include informazioni come l'ID del topic del sensore, il valore della velocità e timestamp che indicano quando i dati sono stati inviati e ricevuti.

### SensorRepository.cs
Questa classe è responsabile dell'interazione con il database per memorizzare i dati del sensore. Include metodi per inserire i dati del sensore nel database in modo asincrono.

### Program.cs
Questo è il punto di ingresso principale dell'applicazione server. Inizializza il ricevitore RabbitMQ, inizia a ricevere messaggi dalla coda specificata e gestisce i dati in ingresso.

## Canale di Comunicazione
Il codice lato server comunica con il codice lato client tramite il protocollo specificato (AMQP in questo caso). La classe `RabbitMQReceiver` ascolta i messaggi sulla coda specificata e li elabora di conseguenza, memorizzando i dati del sensore nel database.