usiusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node
{
    public string name { get; set; }
    public int x { get; set; }
    public int y { get; set; }

    public Node(int xIn, int yIn)
    {
        this.x = xIn;
        this.y = yIn;
    }

    public List<Node> connections = new List<Node>();
    //public Node connection1 = null;
    //public Node connection2 = null;
    //public Node connection3 = null;
    //public Node connection4 = null;
    //public Node connection5 = null;
    //public Node connection6 = null;

    public float costSoFar = 0;
    public float heuristic = 0;
    public float estimatedTotalCost = 0;
    public Node cameFrom = null;

    public void GetConnections(params Node[] node)
    {
        for(int i = 0; i < node.Length; i++){
            connections.Add(node[i]);
        }

    }
}




class Program
{
    static void Main()
    {
        RunNodeMap();

    }

    public static void RunNodeMap()
    {

        string startPos, endPos;

        Console.WriteLine("Please type the name of the starting position. (letter between A and P)");
        startPos = Console.ReadLine();
        checkIfAllowed(startPos);

        Console.WriteLine("Please type the name of the ending position. (letter between A and P)");
        endPos = Console.ReadLine();
        checkIfAllowed(endPos);

        if (startPos == endPos)
        {
            Console.WriteLine("The shortest path is: ");
            Console.WriteLine(startPos);
        }

        else
        {
            findShortestPath(startPos, endPos);
        }

    }

    public static void findShortestPath(string startPos, string endPos)
    {
        Node A = new Node(-19, 11) { name = "A" };
        Node B = new Node(-13, 13) { name = "B" };
        Node C = new Node(4, 14) { name = "C" };
        Node D = new Node(-4, 12) { name = "D" };
        Node E = new Node(-8, 3) { name = "E" };
        Node F = new Node(-18, 1) { name = "F" };
        Node G = new Node(-12, -8) { name = "G" };
        Node H = new Node(12, -9) { name = "H" };
        Node I = new Node(-18, -11) { name = "I" };
        Node J = new Node(-4, -11) { name = "J" };
        Node K = new Node(-12, -14) { name = "K" };
        Node L = new Node(2, -18) { name = "L" };
        Node M = new Node(18, -13) { name = "M" };
        Node N = new Node(4, -9) { name = "N" };
        Node O = new Node(22, 11) { name = "O" };
        Node P = new Node(18, 3) { name = "P" };

        A.GetConnections(B, E);
        B.GetConnections(A, D);
        C.GetConnections(D, E, P);
        D.GetConnections(B, C, E);
        E.GetConnections(A, C, D, G, J, N);
        F.GetConnections(G, I);
        G.GetConnections(E, F, J);
        H.GetConnections(N, P);
        I.GetConnections(F, K);
        J.GetConnections(E, G, K, L);
        K.GetConnections(I, J, L);
        L.GetConnections(J, K, M);
        M.GetConnections(L, O, P);
        N.GetConnections(E, H);
        O.GetConnections(M, P);
        P.GetConnections(C, H, M, O);

        Node startNode;
        Node endNode;
        if (startPos == "a")
            startNode = A;
        else if (startPos == "b")
            startNode = B;
        else if (startPos == "c")
            startNode = C;
        else if (startPos == "d")
            startNode = D;
        else if (startPos == "e")
            startNode = E;
        else if (startPos == "f")
            startNode = F;
        else if (startPos == "g")
            startNode = G;
        else if (startPos == "h")
            startNode = H;
        else if (startPos == "i")
            startNode = I;
        else if (startPos == "j")
            startNode = J;
        else if (startPos == "k")
            startNode = K;
        else if (startPos == "l")
            startNode = L;
        else if (startPos == "m")
            startNode = M;
        else if (startPos == "n")
            startNode = N;
        else if (startPos == "o")
            startNode = O;
        else
            startNode = P;

        if (endPos == "a")
            endNode = A;
        else if (endPos == "b")
            endNode = B;
        else if (endPos == "c")
            endNode = C;
        else if (endPos == "d")
            endNode = D;
        else if (endPos == "e")
            endNode = E;
        else if (endPos == "f")
            endNode = F;
        else if (endPos == "g")
            endNode = G;
        else if (endPos == "h")
            endNode = H;
        else if (endPos == "i")
            endNode = I;
        else if (endPos == "j")
            endNode = J;
        else if (endPos == "k")
            endNode = K;
        else if (endPos == "l")
            endNode = L;
        else if (endPos == "m")
            endNode = M;
        else if (endPos == "n")
            endNode = N;
        else if (endPos == "o")
            endNode = O;
        else
            endNode = P;


        List<Node> openNodes = new List<Node>();
        List<Node> closedNodes = new List<Node>();

        
        float deltaX = endNode.x - startNode.x;
        float deltaY = endNode.y - startNode.y;
        startNode.heuristic = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        startNode.estimatedTotalCost = startNode.heuristic + startNode.costSoFar;
        processNode(workingNode, endNode, openNodes, closedNodes);
    }

    private static void processNode(Node workingNode, Node endNode, List<Node> openNodes, List<Node> closedNodes)
    {
        foreach (Node node in workingNode.connections) { 
            float deltaX = workingNode.x - node.x;
            float deltaY = workingNode.y - node.y;
            node.costSoFar = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            deltaX = node.x - endNode.x;
            deltaY = node.y - endNode.y;
            node.heuristic = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            if (openNodes.Contains(node)) { 
            
            }
            node.estimatedTotalCost = node.costSoFar + node.heuristic;
            node.cameFrom = workingNode;
            openNodes.Add(node);
        }
        closedNodes.Add(workingNode);
    }

    private static void checkConnections()
    {
        ;
    }

    private static void walkBackPath(Node workingNode)
    {
        Node currentNode = workingNode;
        Console.WriteLine("The shortest path is:");
        Console.Write("Starting at " + currentNode.name);
        while (currentNode.cameFrom != null) {          
            Console.Write(currentNode.cameFrom.name + " ");
            currentNode = currentNode.cameFrom;
        }
    }

    private static void checkIfAllowed(string input)
    {
        int isAllowed = input.CompareTo("p");
        if (isAllowed == 1)
        {
            throw new Exception("The start or end node does not exist.");
        }
    }
}