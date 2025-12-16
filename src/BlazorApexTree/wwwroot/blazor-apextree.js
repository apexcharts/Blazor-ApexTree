window.blazorApexTree = (() => {
  // store tree instances
  const instances = {};

  return {
    /**
     * initialize ApexTree instance
     * @param {string} elementId - container element id
     * @param {object} options - tree configuration options
     * @param {object} dotNetRef - reference to blazor component for callbacks
     */
    init: (elementId, options, dotNetRef) => {
      try {
        const element = document.getElementById(elementId);
        if (!element) {
          console.error(`Element with id '${elementId}' not found`);
          return false;
        }

        // store dotnet reference for event callbacks
        if (dotNetRef) {
          instances[elementId] = { dotNetRef };
        }

        console.log("ApexTree initialized for:", elementId);
        return true;
      } catch (error) {
        console.error("Error initializing ApexTree:", error);
        return false;
      }
    },

    /**
     * render tree with data
     * @param {string} elementId - container element id
     * @param {object} data - tree data structure
     * @param {object} options - tree configuration options
     */
    render: (elementId, data, options) => {
      try {
        // check if ApexTree is loaded
        if (typeof ApexTree === "undefined") {
          console.error(
            "❌ ApexTree library not loaded! Make sure apextree.min.js is included before blazor-apextree.js"
          );
          console.error(
            "Expected path: _content/BlazorApexTree/apextree.min.js"
          );
          return false;
        }

        const element = document.getElementById(elementId);
        if (!element) {
          console.error(`Element with id '${elementId}' not found`);
          return false;
        }

        console.log("✅ ApexTree library loaded");
        console.log("Rendering tree with options:", options);
        console.log("Tree data:", data);

        // create apextree instance
        const tree = new ApexTree(element, options);
        const graph = tree.render(data);

        // store instance
        if (!instances[elementId]) {
          instances[elementId] = {};
        }
        instances[elementId].tree = tree;
        instances[elementId].graph = graph;

        // attach event listeners if dotnet reference exists
        if (instances[elementId].dotNetRef) {
          attachEventListeners(elementId, element);
        }

        console.log("✅ Tree rendered successfully");
        return true;
      } catch (error) {
        console.error("❌ Error rendering ApexTree:", error);
        console.error("Stack trace:", error.stack);
        return false;
      }
    },

    /**
     * set license key for ApexTree
     * @param {string} licenseKey - commercial license key
     */
    setLicense: (licenseKey) => {
      try {
        if (typeof ApexTree !== "undefined" && ApexTree.setLicense) {
          ApexTree.setLicense(licenseKey);
          return true;
        }
        console.warn("ApexTree.setLicense not available");
        return false;
      } catch (error) {
        console.error("Error setting license:", error);
        return false;
      }
    },

    /**
     * change tree layout direction
     * @param {string} elementId - container element id
     * @param {string} direction - new direction (top, bottom, left, right)
     */
    changeLayout: (elementId, direction) => {
      try {
        const instance = instances[elementId];
        if (!instance || !instance.graph) {
          console.error("Tree instance not found for:", elementId);
          return false;
        }

        instance.graph.changeLayout(direction);
        return true;
      } catch (error) {
        console.error("Error changing layout:", error);
        return false;
      }
    },

    /**
     * expand a node
     * @param {string} elementId - container element id
     * @param {string} nodeId - node id to expand
     */
    expand: (elementId, nodeId) => {
      try {
        const instance = instances[elementId];
        if (!instance || !instance.graph) {
          console.error("Tree instance not found for:", elementId);
          return false;
        }

        instance.graph.expand(nodeId);
        return true;
      } catch (error) {
        console.error("Error expanding node:", error);
        return false;
      }
    },

    /**
     * collapse a node
     * @param {string} elementId - container element id
     * @param {string} nodeId - node id to collapse
     */
    collapse: (elementId, nodeId) => {
      try {
        const instance = instances[elementId];
        if (!instance || !instance.graph) {
          console.error("Tree instance not found for:", elementId);
          return false;
        }

        instance.graph.collapse(nodeId);
        return true;
      } catch (error) {
        console.error("Error collapsing node:", error);
        return false;
      }
    },

    /**
     * fit tree to screen
     * @param {string} elementId - container element id
     */
    fitScreen: (elementId) => {
      try {
        const instance = instances[elementId];
        if (!instance || !instance.graph) {
          console.error("Tree instance not found for:", elementId);
          return false;
        }

        instance.graph.fitScreen();
        return true;
      } catch (error) {
        console.error("Error fitting to screen:", error);
        return false;
      }
    },

    /**
     * destroy tree instance and cleanup
     * @param {string} elementId - container element id
     */
    destroy: (elementId) => {
      try {
        const instance = instances[elementId];
        if (instance) {
          // cleanup event listeners
          const element = document.getElementById(elementId);
          if (element) {
            removeEventListeners(elementId, element);
          }

          // remove instance
          delete instances[elementId];
        }
        return true;
      } catch (error) {
        console.error("Error destroying ApexTree:", error);
        return false;
      }
    },
  };

  // helper function to attach event listeners
  function attachEventListeners(elementId, element) {
    const instance = instances[elementId];
    if (!instance || !instance.dotNetRef) return;

    // node click handler
    const clickHandler = (event) => {
      const nodeElement = event.target.closest("[data-node-id]");
      if (nodeElement) {
        const nodeId = nodeElement.getAttribute("data-node-id");
        instance.dotNetRef.invokeMethodAsync("OnNodeClickedFromJs", nodeId);
      }
    };

    // node hover handler
    const hoverHandler = (event) => {
      const nodeElement = event.target.closest("[data-node-id]");
      if (nodeElement) {
        const nodeId = nodeElement.getAttribute("data-node-id");
        instance.dotNetRef.invokeMethodAsync("OnNodeHoveredFromJs", nodeId);
      }
    };

    // store handlers for cleanup
    instance.clickHandler = clickHandler;
    instance.hoverHandler = hoverHandler;

    // attach listeners
    element.addEventListener("click", clickHandler);
    element.addEventListener("mouseover", hoverHandler);
  }

  // helper function to remove event listeners
  function removeEventListeners(elementId, element) {
    const instance = instances[elementId];
    if (!instance) return;

    if (instance.clickHandler) {
      element.removeEventListener("click", instance.clickHandler);
    }
    if (instance.hoverHandler) {
      element.removeEventListener("mouseover", instance.hoverHandler);
    }
  }
})();
