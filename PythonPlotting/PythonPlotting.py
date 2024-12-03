from decimal import Decimal
from turtle import title
import matplotlib.pyplot as plt
import matplotlib.markers
import os
import numpy as np

def read_data(file_path):
    with open(file_path, 'r') as file:
        lines = file.readlines()

    headers = lines[0].strip().split(' ')
    x_axis = lines[1].strip().split(' ')
    data=[]
    counter = 0
    for line in lines[2:]:  
        arr=[]
        for item in line.strip().split(' '):
            try:
                # Try converting the item to Decimal and appending it
                arr.append(Decimal(item.replace(',','.')))
            except:
                print(f"Invalid item found: {item} - cannot convert to Decimal")
        data.append(arr)
        arr.clear
    
    return headers, x_axis, data
 
def plotFunc(title, sizes, minArr, avgArr, maxArr):
    plt.title(f"Matrix multiplication {title} performance")
    plt.plot(sizes, minArr, color='r', label='Min')
    plt.plot(sizes, avgArr, color='g', label='Average')
    plt.plot(sizes, maxArr, color='b', label='Max')
    plt.ylabel("Time[ms]")
    plt.xlabel("Matrix sizes")
    plt.yscale("log")
    #plt.ylim(minArr, maxArr)
    plt.grid(True)
    #plt.show()
    plt.legend()
    plt.savefig(f'{title}_on_one')
    plt.close()

    fig, axs = plt.subplots(3, 1, figsize=(8, 12))  # 3 rows, 1 column

    # Min Plot
    axs[0].plot(sizes, minArr, color='r', marker='o', label='Min')
    for i, size in enumerate(sizes):
        axs[0].annotate(f"{minArr[i]:.2f}", (size, minArr[i]), textcoords="offset points", xytext=(0, 5), ha='center',
                        fontsize=8, color='r')
    axs[0].set_yscale("log")
    axs[0].set_title(f"Matrix multiplication {title} Min")
    axs[0].set_ylabel("Time [ms]")
    axs[0].grid(True)

    # Average Plot
    axs[1].plot(sizes, avgArr, color='g', marker='o', label='Average')
    for i, size in enumerate(sizes):
        axs[1].annotate(f"{avgArr[i]:.2f}", (size, avgArr[i]), textcoords="offset points", xytext=(0, 5), ha='center',
                        fontsize=8, color='g')
    axs[1].set_yscale("log")
    axs[1].set_title(f"Matrix multiplication {title} Average")
    axs[1].set_ylabel("Time [ms]")
    axs[1].grid(True)

    # Max Plot
    axs[2].plot(sizes, maxArr, color='b', marker='o', label='Max')
    for i, size in enumerate(sizes):
        axs[2].annotate(f"{maxArr[i]:.2f}", (size, maxArr[i]), textcoords="offset points", xytext=(0, 5), ha='center',
                        fontsize=8, color='b')
    axs[2].set_yscale("log")
    axs[2].set_title(f"Matrix multiplication {title} Max")
    axs[2].set_xlabel("Matrix sizes")
    axs[2].set_ylabel("Time [ms]")
    axs[2].grid(True)

    #plt.tight_layout()
    #plt.show()
    #plt.tight_layout()
    #plt.show()
    plt.savefig(f"{title}")
    plt.close()


def plotComparison(titles, sizes, y_points):
    for i in range(0, len(y_points), 2):
        plt.figure(figsize=(8, 6))
        plt.title("Matrix multiplication performance comparison")

        # Plot the first set of points (Red)
        plt.plot(sizes, y_points[i], color='r', marker='o', label=f'{titles[i]}')
        for j, size in enumerate(sizes):
            plt.annotate(f"{y_points[i][j]:.2f}", (size, y_points[i][j]), textcoords="offset points", xytext=(0, 5),
                         ha='center', fontsize=8, color='r')

        # Plot the second set of points (Green)
        plt.plot(sizes, y_points[i + 1], color='g', marker='o', label=f'{titles[i + 1]}')
        for j, size in enumerate(sizes):
            plt.annotate(f"{y_points[i + 1][j]:.2f}", (size, y_points[i + 1][j]), textcoords="offset points",
                         xytext=(0, 5), ha='center', fontsize=8, color='g')

        plt.ylabel("Time [ms]")
        plt.xlabel("Matrix sizes")
        plt.legend()
        plt.yscale("log")
        plt.grid(True)
        #plt.savefig(f'{titles[i]} and {titles[i+1]}')
        #plt.show()
        #plt.close()

def plotEffectiveness(title, sizes, data):
    plt.title(f"{title}")
    plt.plot(sizes, data, color='g',marker='o', label='Effectiveness')
    plt.ylabel("Time[ms]")
    plt.xlabel("Matrix sizes")
    # plt.ylim(minArr, maxArr)
    plt.grid(True)

    for x, y in zip(sizes, data):
        plt.annotate(f"{round(y,4)}",  # Format the annotation with two decimal places
                     (x, y),  # Position of the annotation
                     textcoords="offset points",  # Specify how to position the text
                     xytext=(5, 5),  # Offset for the text
                     ha='center',  # Horizontal alignment
                     fontsize=9,  # Font size for annotations
                     color='black')  # Color of the text
    #plt.show()
    # plt.legend()
    #plt.savefig(f'{title}_Effectiveness')
    #plt.close()
    
def plotPerformance(title, sizes, data):
    plt.title(f"{title}")
    plt.plot(sizes, data, color='g',marker='o', label='Performance')
    plt.ylabel("Speedup")
    plt.xlabel("Matrix sizes")
    # plt.ylim(minArr, maxArr)
    plt.grid(True)
    for x, y in zip(sizes, data):
        plt.annotate(f"{round(y,4)}",  # Format the annotation with two decimal places
                     (x, y),  # Position of the annotation
                     textcoords="offset points",  # Specify how to position the text
                     xytext=(5, 5),  # Offset for the text
                     ha='center',  # Horizontal alignment
                     fontsize=9,  # Font size for annotations
                     color='black')  # Color of the text
    #plt.show()
    # plt.legend()
    plt.savefig(f'{title}_Seeedup')
    plt.close()

if __name__ == "__main__":
    # Specify the path to your .txt file
    file_path = r"D:\Studia\ISA-magister\sem_2\Obliczenia_wys_wydajnosci\Projekt\temat1\PythonPlottin\PlottingData\DataForPlotting"
    path = r"D:\Studia\ISA-magister\sem_2\Obliczenia_wys_wydajnosci\Projekt\temat1\PythonPlottin\PlottingData\IMAGES"
    # Read data from the file
    headersLined, sizesLined, numbersLined = read_data(file_path+"\FOR_PRESENTATION_LINED.txt")


    numbersLined = np.array(numbersLined)
    data = []
    for i in range(len(numbersLined)):
        #print(len(numbersLined[i]))
        data.append(numbersLined[i].reshape(12,4))
    
    minArr = []
    maxArr = []
    avgArr = []
    for x in data:
        temp1 = []
        temp2 = []
        temp3 = []
        for y in x:
            min_number = min(y)
            max_number = max(y)
            avg_number = np.average(y)
            temp1.append(min_number)
            temp2.append(max_number)
            temp3.append(avg_number)
            #print(avg_number)
        minArr.append(temp1)
        maxArr.append(temp2)
        avgArr.append(temp3)
        #print("------------")

    #effectiveness 
    #Effectiveness = []
    #
    #
    #for i in range(0, len(avgArr), 2):
    #    temp = []
    #    for j in range(0,len(avgArr[i])):
    #        e = avgArr[i+1][j]/avgArr[i][j]
    #        temp.append(e)
    #    Effectiveness.append(temp)
    #
    #EffTitles = ['Int Parallelism Effectiveness', 'Int64 Parallelism Effectiveness', 'Double Parallelism Effectiveness']
    #for i in range(len(Effectiveness)):
    #    plotEffectiveness(EffTitles[i], sizesLined, Effectiveness[i])


    # for i in range(6):
    #     plotFunc(headersLined[i], sizesLined, minArr[i], avgArr[i], maxArr[i])

    #plotComparison(headersLined, sizesLined, avgArr)
   
   #performance
    performance = []


    for i in range(0, len(avgArr), 2):
        temp = []
        for j in range(0,len(avgArr[i])):
            e = avgArr[i][j]/avgArr[i+1][j]
            temp.append(e)
        performance.append(temp)
        
        PerformanceTitles = ['Int Parallelism Speedup', 'Int64 Parallelism Speedup', 'Double Parallelism Speedup']
        for i in range(len(performance)):
            plotPerformance(PerformanceTitles[i], sizesLined, performance[i])



    # Plot histogram with normal distribution lines
    # files = []  
    # for name in os.listdir(file_path):
    #    if os.path.isfile(os.path.join(file_path,name)) and 'DataHist' in name:
    #        files.append(name)
    # print(files) 
    # for i in files:
    #    headers, sizes, numbers = read_data(file_path+f"\{i}")
    #    for i in range(len(numbers)):
    #        plot_histogram(headers[i],sizes, numbers[i])