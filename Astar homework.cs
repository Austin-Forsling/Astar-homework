using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node
{

    public int x { get; set; }
    public int y { get; set; }

    public Node(int xIn, int yIn)
    {
        this.x = xIn;
        this.y = yIn;
    }

    public Node connection1 = null;
    public Node connection2 = null;
    public Node connection3 = null;
    public Node connection4 = null;
    public Node connection5 = null;
    public Node connection6 = null;

    public float costSoFar = 0;
    public float heuristic = 0;
    public float estimatedTotalCost = 0;
    public Node cameFrom = null;

    public void GetConnections(Node one = null, Node two = null, Node three = null, Node four = null, Node five = null, Node six = null)
    {
        this.connection1 = one;
        this.connection2 = two;
        this.connection3 = three;
        this.connection4 = four;
        this.connection5 = five;
        this.connection6 = six;
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
        Node A = new Node(-19, 11);
        Node B = new Node(-13, 13);
        Node C = new Node(4, 14);
        Node D = new Node(-4, 12);
        Node E = new Node(-8, 3);
        Node F = new Node(-18, 1);
        Node G = new Node(-12, -8);
        Node H = new Node(12, -9);
        Node I = new Node(-18, -11);
        Node J = new Node(-4, -11);
        Node K = new Node(-12, -14);
        Node L = new Node(2, -18);
        Node M = new Node(18, -13);
        Node N = new Node(4, -9);
        Node O = new Node(22, 11);
        Node P = new Node(18, 3);

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


        closedNodes = checkConnections(startNode, endNode, openNodes, closedNodes);
    }

    private static List<Node> checkConnections(Node currentNode, Node endNode, List<Node> openNodes, List<Node> closedNodes) {

        float deltaX = currentNode.x - endNode.x;
        float deltaY = currentNode.y - endNode.y;
        currentNode.heuristic = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        currentNode.estimatedTotalCost = currentNode.heuristic + currentNode.costSoFar;
        closedNodes.Add(currentNode);

        if (currentNode.connection1 != null) {
            if (closedNodes.Contains(currentNode.connection1)) {
                deltaX = currentNode.x - currentNode.connection1.x;
                deltaY = currentNode.y = currentNode.connection1.y;
                if((currentNode.costSoFar + (deltaX*deltaX + deltaY * deltaY) < currentNode.connection1.costSoFar){
                    currentNode.connection1.costSoFar = currentNode.costSoFar + (deltaX*deltaX + deltaY * deltaY);
                    openNodes.Add(currentNode.connection1);
                    closedNodes.Remove(currentNode.connection1);
                }
            }
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

