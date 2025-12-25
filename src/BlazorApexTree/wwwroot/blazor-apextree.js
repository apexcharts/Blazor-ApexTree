window.blazorApexTree = (() => {
  // store tree instances
  const instances = {};

  /**
   * process options to convert string templates to JavaScript functions
   * @param {object} options - tree configuration options
   * @returns {object} processed options with functions
   */
  function processOptions(options) {
    if (!options) {
      return options;
    }

    const processed = { ...options };

    if (
      typeof processed.tooltipTemplate === "string" &&
      processed.tooltipTemplate.trim()
    ) {
      try {
        const templateFunc = eval("(" + processed.tooltipTemplate + ")");
        processed.tooltipTemplate = templateFunc;
      } catch (error) {
        console.error("9. ❌ Error converting tooltipTemplate:", error);
        delete processed.tooltipTemplate;
      }
    } else {
      if (processed.tooltipTemplate === null) {
        delete processed.tooltipTemplate;
      }
    }

    // process nodeTemplate - only if it's a non-empty string
    if (
      typeof processed.nodeTemplate === "string" &&
      processed.nodeTemplate.trim()
    ) {
      try {
        const templateFunc = eval("(" + processed.nodeTemplate + ")");
        processed.nodeTemplate = templateFunc;
      } catch (error) {
        console.error("❌ Error converting nodeTemplate:", error);
        delete processed.nodeTemplate;
      }
    } else {
      if (processed.nodeTemplate === null) {
        delete processed.nodeTemplate;
      }
    }

    return processed;
  }

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
          return false;
        }

        const element = document.getElementById(elementId);
        if (!element) {
          console.error(`Element with id '${elementId}' not found`);
          return false;
        }

        // process options to convert string templates to functions
        const processedOptions = processOptions(options);

        // create apextree instance
        const tree = new ApexTree(element, processedOptions);
        const graph = tree.render(data);

        // store instance
        if (!instances[elementId]) {
          instances[elementId] = {};
        }
        instances[elementId].tree = tree;
        instances[elementId].graph = graph;

        // wait for DOM to be ready and attach event listeners
        setTimeout(() => {
          attachEventListeners(elementId, element);
        }, 100);

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

        // reattach event listeners after layout change
        setTimeout(() => {
          const element = document.getElementById(elementId);
          if (element) {
            attachEventListeners(elementId, element);
          }
        }, 100);

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

        // reattach event listeners after expand
        setTimeout(() => {
          const element = document.getElementById(elementId);
          if (element) {
            attachEventListeners(elementId, element);
          }
        }, 100);

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

        // reattach event listeners after collapse
        setTimeout(() => {
          const element = document.getElementById(elementId);
          if (element) {
            attachEventListeners(elementId, element);
          }
        }, 100);

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

  // helper function to attach event listeners to SVG nodes
  function attachEventListeners(elementId, containerElement) {
    const instance = instances[elementId];
    if (!instance || !instance.dotNetRef) {
      return;
    }

    // remove old listeners first
    removeEventListeners(elementId, containerElement);

    // find all SVG foreignObject elements (these contain the node content)
    const nodeElements = containerElement.querySelectorAll("foreignObject");

    nodeElements.forEach((nodeElement) => {
      // try to find node id from parent group element
      let nodeId = null;
      let currentElement = nodeElement.parentElement;

      // traverse up to find the group with id
      while (currentElement && !nodeId) {
        if (currentElement.tagName === "g" && currentElement.id) {
          nodeId = currentElement.id;
          break;
        }
        currentElement = currentElement.parentElement;
      }

      if (!nodeId) {
        // fallback: extract from transform or other attributes
        return;
      }

      // create click handler
      const clickHandler = (event) => {
        event.stopPropagation();
        try {
          instance.dotNetRef.invokeMethodAsync("OnNodeClickedFromJs", nodeId);
        } catch (error) {
          console.error("Error invoking OnNodeClickedFromJs:", error);
        }
      };

      // create hover handler
      const hoverHandler = (event) => {
        event.stopPropagation();
        try {
          instance.dotNetRef.invokeMethodAsync("OnNodeHoveredFromJs", nodeId);
        } catch (error) {
          console.error("Error invoking OnNodeHoveredFromJs:", error);
        }
      };

      // store handlers for cleanup
      if (!instance.eventHandlers) {
        instance.eventHandlers = [];
      }

      instance.eventHandlers.push({
        element: nodeElement,
        click: clickHandler,
        hover: hoverHandler,
      });

      // attach listeners
      nodeElement.addEventListener("click", clickHandler);
      nodeElement.addEventListener("mouseenter", hoverHandler);
    });
  }

  // helper function to remove event listeners
  function removeEventListeners(elementId, containerElement) {
    const instance = instances[elementId];
    if (!instance || !instance.eventHandlers) return;

    instance.eventHandlers.forEach(({ element, click, hover }) => {
      element.removeEventListener("click", click);
      element.removeEventListener("mouseenter", hover);
    });

    instance.eventHandlers = [];
  }
})();
