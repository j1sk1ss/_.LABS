from PYTHON_LABS.LABS.DISCRET.FIRST_LAB.OBJECTS.GraphSolver import GraphSolver
from PYTHON_LABS.LABS.Quest import Quest


class First(Quest):
    def __init__(self):
        super().__init__([
            first_task
        ])


def first_task():
    graph_solver = GraphSolver()

    graph_solver.add_graph(["A", "B", "C", "F"], [("A", "B"), ("B", "C"), ("C", "A"), ("C", "C"), ("A", "F")])
    graph_solver.add_graph(["A", "B", "F"], [("A", "B"), ("B", "F"), ("F", "F")])

    graph_solver.display_graph(0)
    graph_solver.adjacency_matrix(0)

    graph_solver.display_graph(1)
    graph_solver.adjacency_matrix(1)

    graph_solver.find_intersection(0, 1)
    graph_solver.unite(0, 1)

    graph_solver.cartesian_product()