# DMMA
 Decision-making methods and algorithms
## Lab №1
* В качестве примера метода распознавания образов, использующего процедуру контролируемого обучения, рассмотрим алгоритм К-средних.
Исходные данные – число образов и число классов (К), на которое нужно разделить все образы. Количество образов предлагается брать в диапазоне от 1000 до 100 000, число классов – от 2 до 20. 
Признаки объектов задаются случайным образом, это координаты векторов. Обычно К элементов из набора векторов случайным образом назначают центрами классов.
Цель и результат работы алгоритма – определить ядрами классов К типичных представителей классов и максимально компактно распределить вокруг них остальные объекты выборки.
* As an example of a pattern recognition method using supervised learning, consider the K-means algorithm.
The initial data are the number of images and the number of classes (K) into which all images should be divided. It is suggested to take the number of images in the range from 1000 to 100 000, the number of classes - from 2 to 20. 
The features of the objects are given randomly, they are the coordinates of the vectors. Usually K elements from the set of vectors are randomly assigned as class centers.
The purpose and result of the algorithm is to define K typical class representatives as class centers and to distribute the rest of the sample objects around them as compactly as possible.
---
## Lab №2
* В качестве примера метода распознавания образов, использующего процедуру самообучения, рассмотрим алгоритм максимина.
Исходные данные – число образов, которые нужно разделить на классы. Количество образов предлагается брать в диапазоне от 1000 до 100000. Признаки объектов задаются случайным образом, это координаты
векторов.
Цель и результат работы алгоритма – исходя из произвольного выбора максимально компактно разделить объекты на классы, определив ядро каждого класса.
* As an example of a pattern recognition method using the self-learning procedure, let us consider the maximin algorithm.
The initial data is the number of images to be divided into classes. It is suggested to take the number of images in the range from 1000 to 100000. The features of the objects are set randomly, they are coordinates of the vectors.
The goal and result of the algorithm is to divide objects into classes as compactly as possible based on a random choice, defining the core of each class.
---
## Lab №3
* Разделение объектов на два класса при вероятностном подходе. Вычислить вероятность ложной тревоги, вероятность пропуска обнаружения ошибки, вероятность суммарной ошибки классификации.
* Divide objects into two classes using a probabilistic approach. Calculate the probability of false alarm, probability of missing error detection, probability of total classification error.
---
## Lab №4
* Классификация объектов на N классов методом персептрона. Найти N решающих функций. После того, как получено N решающих функций, предъявляются объекты тестовой выборки, которые необходимо классифицировать, отнеся к одному из классов. Тестовый объект подставляется в каждую из решающих функций и относится к тому из классов, где было получено максимальное значение. Количество классов, обучающих объектов и их признаков может быть произвольным.
* Classification of objects into N classes by the perseptron method. Find N decision functions. After N solving functions are obtained, test sample objects are presented, which are to be classified by assigning them to one of the classes. The test object is substituted into each of the solving functions and assigned to the one of the classes where the maximum value was obtained. The number of classes, training objects and their features can be arbitrary.
---
## Lab №5
* После того как получено решающее правило и построена разделяющая функция, предъявляются объекты тестовой выборки, которые необходимо классифицировать, отнеся к одному из двух классов. Тестовая выборка также задается векторами с наборами признаков. Результаты работы программы должны представляться в графическом виде. Метод потенциалов относится к группе алгоритмов контролируемого обучения. Задание: по обучающей выборке из 4 – 6 объектов, представленных векторами с наборами признаков построить разделяющую функцию и решающее правило для классификации тестовых объектов.
* Once the decision rule is obtained and the separating function is constructed, the objects of the test sample are presented to be classified into one of the two classes. The test sample is also defined by vectors with feature sets. The results of the program should be presented graphically. The method of potentials belongs to the group of supervised learning algorithms. Task: on the basis of a training sample of 4 - 6 objects represented by vectors with feature sets, construct a separating function and a decisive rule for classifying test objects
---
## Lab №6
* Методы распознавания, где классы известны заранее и разделяющие функции вырабатывались в процессе обучения, сильно влияют на выбор признаков и критериев разделения, от которых зависит получаемый результат. Для того чтобы уменьшить влияние первоначальных сведений, их обогащают дополнительной информацией. Например, уточняют пространственные или временные отношения; находят существующие отношения между исследуемыми объектами. Такие действия называются символическим описанием, которое получается в результате процедуры группирования, выполняющей роль и процедуры классификации. Искомое символическое представление может иметь вид иерархической структуры, дерева минимальной длины или символического описания классов. Иерархия строится на основе понятия расстояния. Метод состоит в том, чтобы разработать последовательность разделений рассматриваемого множества на подгруппы, одна из которых обладает некоторым свойством, неприсущим другим. Искомая иерархия основывается на предъявляемых выборках. Поскольку их число весьма велико, иногда на одном и том же множестве исходных данных могут быть получены различные иерархии.Построить иерархии, построенные по критериям минимума и максимума. 
* Recognition methods where the classes are known in advance and the separating functions are developed during training, strongly influence the choice of features and separation criteria on which the result depends. In order to reduce the influence of initial information, they are enriched with additional information. For example, they clarify spatial or temporal relations; find existing relations between the investigated objects. Such actions are called symbolic description, which is obtained as a result of the grouping procedure, which performs the role of and classification procedure. The sought symbolic representation may take the form of a hierarchical structure, a minimum length tree or a symbolic description of classes. The hierarchy is constructed based on the concept of distance. The method consists in developing a sequence of subdivisions of the set under consideration into subgroups, one of which possesses some property that is not inherent in the others. The hierarchy sought is based on the samples presented. Since their number is very large, sometimes different hierarchies can be obtained on the same set of initial data.Construct hierarchies based on the minimum and maximum criteria. 
---
## Lab №7
---
## Lab №8
---
## Lab №9
---
