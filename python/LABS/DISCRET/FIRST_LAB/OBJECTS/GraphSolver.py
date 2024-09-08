import matplotlib.pyplot as plt
import numpy as np
import networkx as nx


class GraphSolver:
    def __init__(self):
        self.graphs = []

    def add_graph(self, vertices, edges):
        G = nx.Graph()
        G.add_nodes_from(vertices)
        G.add_edges_from(edges)
        self.graphs.append(G)

    def display_graph(self, graph_index):
        G = self.graphs[graph_index]
        pos = nx.spring_layout(G)
        nx.draw(G, pos, with_labels=True, font_weight='bold')
        plt.show()

    def show_current_graph(self, graph):
        G = graph
        pos = nx.spring_layout(G)
        nx.draw(G, pos, with_labels=True, font_weight='bold')
        plt.show()

    def adjacency_matrix(self, graph_index):
        G = self.graphs[graph_index]
        matrix_size = len(G.nodes)
        adjacency_matrix = np.zeros((matrix_size, matrix_size), dtype=int)

        for edge in G.edges:
            start_index = list(G.nodes).index(edge[0])
            end_index = list(G.nodes).index(edge[1])
            adjacency_matrix[start_index, end_index] = 1
            adjacency_matrix[end_index, start_index] = 1  # if the graph is undirected

        print(f"Adjacency matrix for Graph {graph_index + 1}:")
        print(adjacency_matrix)

    def find_intersection(self, first_index, second_index):
      if len(self.graphs) < 2:
          print("Error: Need at least two graphs to find intersection.")
          return

      self.show_current_graph(nx.intersection(self.graphs[first_index], self.graphs[second_index]))
      return

    def unite(self, first_index, second_index):
      if len(self.graphs) < 2:
          print("Error: Need at least two graphs to find intersection.")
          return

      self.show_current_graph(nx.compose(self.graphs[first_index], self.graphs[second_index]))
      return

    def cartesian_product(self):
        if len(self.graphs) < 2:
            print("Error: Need at least two graphs to find Cartesian product.")
            return

        cartesian_graph = nx.cartesian_product(self.graphs[0], self.graphs[1])

        print("Cartesian Product Graph:")
        pos = nx.spring_layout(cartesian_graph)
        nx.draw(cartesian_graph, pos, with_labels=True, font_weight='bold')
        plt.show()