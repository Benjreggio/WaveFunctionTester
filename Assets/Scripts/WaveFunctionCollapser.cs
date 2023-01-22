using System;

public class WaveFunctionCollapser
{
	public bool[,] matRules;
	public int[] dimensions;
	public int[] weights;
	bool[,,,] optGrid;
	int N;

	public WaveFunctionCollapser(bool[,] matRules)
	{
		//this.matRules = matRules;
		//N = matRules.Length;
	}

	public void makeGrid(int[] weights, int[] dimensions)
	{
		this.weights = weights;
		this.dimensions = dimensions;
		optGrid = new bool[dimensions[0],dimensions[1],dimensions[2],N];

		double smallestEntropy = getSmallestEntropy();
		while(smallestEntropy > 0)
		{
			int[] nextLocation = getNextLocation(smallestEntropy);
			
		}
	}

	int[] getNextLocation(double smallestEntropy)
	{
		int[] nextLocation = new int[]{0,0,0};
		return nextLocation;
	}

	double getSmallestEntropy()
	{
		return 0;
	}
}
