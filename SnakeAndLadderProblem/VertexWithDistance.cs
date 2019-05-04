using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeAndLadderProblem
{
    class VertexWithDistance
    {
        int vertex;
        int distance;

        public VertexWithDistance(int vertex, int distance) {
            this.vertex = vertex;
            this.distance = distance;
        }

        public int GetVertex() {
            return vertex;
        }

        public int GetVertexDistance() {
            return distance;
        }

        public void SetVertex(int value) {
            this.vertex = value;
        }

        public void SetVertexDistance(int value) {
            this.distance = value;
        }
    }
}
