
# Client Side Documentation

## Introduction
The client-side code consists of protocols and sensors responsible for collecting and transmitting data to a server. These components facilitate communication between the client application and the server, allowing seamless exchange of information.

### Mqtt.cs
This class defines an MQTT protocol implementation for sending data to a specified endpoint. It utilizes the `MqttClient` class from the MQTTnet library. Upon instantiation, it establishes a connection to the MQTT broker specified by the endpoint. The `Send` method constructs an MQTT message with sensor data and publishes it to a topic derived from the sensor type.

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
This is the main entry point of the client application. It instantiates sensors, defines the communication protocol, and continuously sends sensor data to the server.

## Communication Channel
The client-side code communicates with the server-side code via MQTT protocol. The `Mqtt` protocol implementation sends data to the MQTT broker specified by the endpoint using MQTT publish messages. The server-side code, acting as an MQTT subscriber, listens for messages published on specific topics.

---

# Codice Lato Client

## Introduzione
Il codice lato client consiste in protocolli e sensori responsabili della raccolta e trasmissione dei dati a un server. Questi componenti facilitano la comunicazione tra l'applicazione client e il server, consentendo lo scambio di informazioni senza soluzione di continuità.

### Mqtt.cs
Questa classe definisce un'implementazione del protocollo MQTT per l'invio di dati a un endpoint specificato. Utilizza la classe `MqttClient` dalla libreria MQTTnet. All'istanziazione, stabilisce una connessione al broker MQTT specificato dall'endpoint. Il metodo `Send` costruisce un messaggio MQTT con i dati del sensore e lo pubblica su un topic derivato dal tipo di sensore.

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
Questo è il punto di ingresso principale dell'applicazione client. Istanzia i sensori, definisce il protocollo di comunicazione e invia continuamente i dati del sensore al server.

## Canale di Comunicazione
Il codice lato client comunica con il codice lato server tramite il protocollo MQTT. L'implementazione del protocollo `Mqtt` invia dati al broker MQTT specificato dall'endpoint utilizzando messaggi MQTT di pubblicazione. Il codice lato server, agendo come sottoscrittore MQTT, ascolta i messaggi pubblicati su topic specifici.

---

# Server Side Documentation

## Introduction
The server-side code consists of components responsible for receiving data from client applications via MQTT protocol. It handles incoming messages, processes them, and stores the data in a database. The server exposes functionality to subscribe to specific topics and receive data updates.

### MqttSubscriber.cs
This class represents an MQTT subscriber responsible for receiving messages from the MQTT broker. It connects to the broker, subscribes to specific topics, and processes incoming messages. The received messages are decoded and stored in the database.

### SensorData.cs
This class represents the data received from sensors. It includes information such as the sensor topic ID, speed value, and timestamps indicating when the data was sent and received.

### SensorRepository.cs
This class is responsible for interacting with the database to store sensor data. It includes methods to insert sensor data into the database asynchronously.

### Program.cs
This is the main entry point of the server application. It initializes the MQTT subscriber, connects to the MQTT broker, and subscribes to relevant topics to receive sensor data updates.

## Communication Channel
The server-side code communicates with the client-side code via MQTT protocol. The `MqttSubscriber` class connects to the MQTT broker, subscribes to specific topics, and receives messages published by the client-side code. These messages contain sensor data, which is then processed and stored in the database.

---

# Codice Lato Server

## Introduzione
Il codice lato server consiste in componenti responsabili di ricevere dati dalle applicazioni client tramite il protocollo MQTT. Gestisce i messaggi in arrivo, li elabora e archivia i dati in un database. Il server espone funzionalità per sottoscrivere specifici topic e ricevere aggiornamenti dei dati.

### MqttSubscriber.cs
Questa classe rappresenta un sottoscrittore MQTT responsabile di ricevere messaggi dal broker MQTT. Si connette al broker, si sottoscrive a topic specifici ed elabora i messaggi in arrivo. I messaggi ricevuti vengono decodificati e memorizzati nel database.

### SensorData.cs
Questa classe rappresenta i dati ricevuti dai sensori. Include informazioni come l'ID del topic del sensore, il valore di velocità e i timestamp che indicano quando i dati sono stati inviati e ricevuti.

### SensorRepository.cs
Questa classe è responsabile dell'interazione con il database per

 memorizzare i dati del sensore. Include metodi per inserire dati del sensore nel database in modo asincrono.

### Program.cs
Questo è il punto di ingresso principale dell'applicazione server. Inizializza il sottoscrittore MQTT, si connette al broker MQTT e si sottoscrive ai topic rilevanti per ricevere gli aggiornamenti dei dati del sensore.

## Canale di Comunicazione
Il codice lato server comunica con il codice lato client tramite il protocollo MQTT. La classe `MqttSubscriber` si connette al broker MQTT, si sottoscrive a topic specifici e riceve messaggi pubblicati dal codice lato client. Questi messaggi contengono dati del sensore, che vengono quindi elaborati e memorizzati nel database.